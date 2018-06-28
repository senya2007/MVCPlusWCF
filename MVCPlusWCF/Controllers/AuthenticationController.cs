using MVCPlusWCF.ServiceMappers;
using MVCPlusWCF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCPlusWCF.Controllers
{
    public class AuthenticationController : Controller
    {
        IUserMapper mapper;
        IAuthenticationService authenticationService;

        public AuthenticationController(IUserMapper mapper, IAuthenticationService authenticationService)
        {
            this.mapper = mapper;
            this.authenticationService = authenticationService;
        }
        // GET: Authorize
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string login, string password)
        {
            try
            {
                var result = await authenticationService.IsUserAuthentication(login, password);
                if (result)
                {

                    var user = await mapper.GetUserByLoginAsync(login);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(login, true);
                        System.Web.Security.Roles.AddUsersToRole(new[] { user.Login }, user.Role.ToString());
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            catch (Exception e)
            {
                MvcApplication.logger.Error(e.InnerException, "Ошибка аутентификации");
            }
            MvcApplication.logger.Error("Ошибка пользователя/пароля");
            ModelState.AddModelError(string.Empty, "Ошибка пользователя/пароля");
            return View("Index");
        }
    }
}