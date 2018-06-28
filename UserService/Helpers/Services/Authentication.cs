using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserService.Mappers;

namespace UserService.Helper.Services
{
    public class Authentication : IAuthentication
    {
        IUserMapper mapper;

        public Authentication(IUserMapper mapper)
        {
            this.mapper = mapper;
        }

        public bool IsUserAuthentication(string login, string password)
        {
            bool result = false;
            try
            {
                result = mapper.IsUserAuthentication(login, password);
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }
    }
}