using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPlusWCF.Models;

namespace MVCPlusWCF.BLL
{
    public class UserConverter : IUserConverter
    {
        public UsersTableForAdmin ConvertUserToUsersDataTableForAdmin(User user)
        {
            return new UsersTableForAdmin
            {
                Id = user.Id,
                Login = user?.Login,
                Name = user?.Name,
                Password = user?.Password,
                Patronymic = user?.Patronymic,
                Phone = user?.Phone,
                Role = user.Role,
                Surname = user?.Surname
            };
        }

        public UsersTableForUser ConvertUserToUsersDataTableForUser(User user)
        {
            return new UsersTableForUser
            {
                Name = user?.Name,
                Patronymic = user?.Patronymic,
                Phone = user?.Phone,
                Surname = user?.Surname
            };
        }
    }
}