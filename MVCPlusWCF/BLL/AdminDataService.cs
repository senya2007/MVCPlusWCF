using MVCPlusWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPlusWCF.BLL
{
    public class AdminDataService: IAdminDataService
    {
        public List<UsersTableForAdmin> GetUsers(List<User> users)
        {
            List<UsersTableForAdmin> resultUsers = new List<UsersTableForAdmin>();

            users.ForEach(x => resultUsers.Add(new UsersTableForAdmin
            {
                Id = x.Id,
                Login = x?.Login,
                Name = x?.Name,
                Password = x?.Password,
                Patronymic = x?.Patronymic,
                Phone = x?.Phone,
                Role = x.Role,
                Surname = x?.Surname
            }));

            return resultUsers;
        }
    }
}