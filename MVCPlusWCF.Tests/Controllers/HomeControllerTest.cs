using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCPlusWCF;
using MVCPlusWCF.BLL;
using MVCPlusWCF.Controllers;
using MVCPlusWCF.Mappers;
using MVCPlusWCF.Models;

namespace MVCPlusWCF.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        MVCPlusWCF.UserService.IUserService service = new MVCPlusWCF.UserService.UserServiceClient();

        [TestMethod]
        public void IndexTest()
        {
            HomeController controller = InitController();

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AdminIndexTest()
        {
            HomeController controller = InitController();

            ViewResult result = controller.AdminIndex() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UserIndexTest()
        {
            HomeController controller = InitController();

            ViewResult result = controller.UserIndex() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAdminDataTest()
        {
            HomeController controller = InitController();

            JsonResult result = controller.GetAdminData().Result as JsonResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateAndDeleteUserTest()
        {
            User user = new User {
                Login = "temp",
                Name = "temp",
                Password = "temp",
                Patronymic = "temp",
                Phone = "temp",
                Role = Role.User,
                Surname = "temp"
            };

            HomeController controller = InitController();

            JsonResult createResult = controller.AddOrEdit(user).Result as JsonResult;
            User deleteUser = new UserMapper().ConvertServiceUserToUser(service.GetUserByLoginAsync(user.Login).Result);

            JsonResult deleteResult = controller.Delete(deleteUser).Result as JsonResult;
            Assert.IsNotNull(createResult);
            Assert.IsNotNull(deleteResult);
        }
        
        [TestMethod]
        public void AddOrEditTest()
        {
            HomeController controller = InitController();

            ViewResult result = controller.AddOrEdit().Result as ViewResult;

            Assert.IsNotNull(result);
        }

        HomeController InitController()
        {
            return new HomeController(new UserMapper(service), new DataFromRole(new UserMapper(service), new UserDataService(), new AdminDataService()), new UserConverter());
        }
    }
}
