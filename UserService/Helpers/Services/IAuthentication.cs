using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserService.Helper.Services
{
    public interface IAuthentication
    {
        bool IsUserAuthentication(string login, string password);
    }
}