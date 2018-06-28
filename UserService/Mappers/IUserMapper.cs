using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserService.Models;

namespace UserService.Mappers
{
    public interface IUserMapper
    {
        bool CreateUser(User user);
        void EditUser(User user);
        bool DeleteUser(User user);
        List<User> GetAllUsers();
        bool IsUserAuthentication(string login, string password);
        User GetUserByLogin(string login);
    }
}