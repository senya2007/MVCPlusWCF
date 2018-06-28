using MVCPlusWCF.BLL;
using MVCPlusWCF.Filters;
using MVCPlusWCF.Models;
using MVCPlusWCF.ServiceMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPlusWCF.Controllers
{
    public class HomeController : Controller
    {
        IUserMapper mapper;
        IDataFromRole dataFromRole;
        IUserConverter userConverter;

        public HomeController(IUserMapper mapper, IDataFromRole dataFromRole, IUserConverter userConverter)
        {
            this.mapper = mapper;
            this.dataFromRole = dataFromRole;
            this.userConverter = userConverter;
        }

        [RedirectByRoleFilter]
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeFilter(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [AuthorizeFilter(Roles = "User")]
        public ActionResult UserIndex()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetAdminData()
        {
            return Json(await dataFromRole.GetAdminDataFromUsers(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<ActionResult> GetUserData()
        {
            return Json(await dataFromRole.GetUserDataFromUsers(), JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public async Task<ActionResult> AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new UsersTableForAdmin());
            else
            {
                var users = await mapper.GetAllUsersAsync();
                return View(userConverter.ConvertUserToUsersDataTableForAdmin(users.Where(x => x.Id == id).FirstOrDefault()));
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrEdit(User user)
        {
            if (user.Id == 0)
            {
                var result = await mapper.CreateUserAsync(user);
                return Json(new { success = result, message = (result) ? "Saved Successfully" : "Fail" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                await mapper.EditUserAsync(user);
                return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include ="Id")]User user)
        {
            var result = await mapper.DeleteUserAsync(user);
            return Json(new { success = result, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            MvcApplication.logger.Info("Выход пользователя");
            return RedirectToAction("Index", "Authentication");
        }
    }
}