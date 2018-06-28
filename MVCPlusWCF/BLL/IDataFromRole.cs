using MVCPlusWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCPlusWCF.BLL
{
    public interface IDataFromRole
    {
        Task<object> GetUserDataFromUsers();
        Task<object> GetAdminDataFromUsers();
    }
}