using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserService.Tests
{
    [TestClass]
    public class ServiceTest
    {
        UserService.IUserService service = new UserService.UserServiceClient();

        UserService.User user = new UserService.User
        {
            Login = "temp",
            Name = "temp",
            Password = "temp",
            Patronymic = "temp",
            Phone = "temp",
            Role = UserService.Role.User,
            Surname = "temp"
        };

        [TestMethod]
        public void CreateDeleteUserTest()
        {

            var result = service.CreateUserAsync(user).Result;
            var deleteUser = service.GetUserByLoginAsync(user.Login).Result;
            var deleteResult = service.DeleteUserAsync(deleteUser).Result;
            Assert.AreEqual(true, result);
            Assert.AreEqual(true, deleteResult);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            var findUser = service.GetUserByLoginAsync("admin").Result;
            Assert.IsNotNull(findUser);
        }

        [TestMethod]
        public void GetAllUsersTest()
        {
            var users = service.GetAllUsersAsync().Result;
            Assert.AreEqual(true, users.Length > 0);
        }

        [TestMethod]
        public void AuthTest()
        {
            var result = service.IsUserAuthenticationAsync("admin", "password").Result;
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void EditUserTest()
        {
            var result = service.CreateUserAsync(user).Result;
            var findUser = service.GetUserByLoginAsync(user.Login).Result;
            findUser.Name = "test";

            service.EditUser(findUser);

            var editUser = service.GetUserByLoginAsync(user.Login).Result;
            var deleteResult = service.DeleteUserAsync(editUser).Result;
            Assert.AreEqual("test", editUser.Name);
        }
    }
}
