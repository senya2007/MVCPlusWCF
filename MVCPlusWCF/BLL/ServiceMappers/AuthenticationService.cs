using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCPlusWCF.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        MVCPlusWCF.UserService.IUserService service;

        public AuthenticationService()
        {
            service = new MVCPlusWCF.UserService.UserServiceClient();
        }

        public async Task<bool> IsUserAuthentication(string login, string password)
        {
            return await service.IsUserAuthenticationAsync(login, password);
        }
    }
}