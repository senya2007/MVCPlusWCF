using MVCPlusWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPlusWCF.BLL
{
    public interface IAdminDataService: IUsersDataByRole<UsersTableForAdmin>
    {
    }
}