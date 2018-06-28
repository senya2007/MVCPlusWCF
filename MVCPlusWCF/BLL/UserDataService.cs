using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPlusWCF.Models;

namespace MVCPlusWCF.BLL
{
    public class UserDataService : IUserDataService
    {
        public List<UsersTableForUser> GetUsers(List<User> users)
        {
            List<UsersTableForUser> resultUsers = new List<UsersTableForUser>();

            users.ForEach(x => resultUsers.Add(new UsersTableForUser
            {
                Id = x.Id,
                Name = x?.Name,
                Surname = x?.Surname,
                Patronymic = x?.Patronymic,
                Phone = x?.Phone
            }));

            return resultUsers;
        }
    }
}