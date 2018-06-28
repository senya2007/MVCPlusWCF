using MVCPlusWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPlusWCF.BLL
{
    public interface IUserConverter
    {
       UsersTableForAdmin ConvertUserToUsersDataTableForAdmin(User user);
       UsersTableForUser ConvertUserToUsersDataTableForUser(User user);
    }
}