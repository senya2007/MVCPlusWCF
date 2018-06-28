using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCPlusWCF.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsUserAuthentication(string login, string password);
    }
}