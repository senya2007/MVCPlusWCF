using MVCPlusWCF.Models;
using MVCPlusWCF.ServiceMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVCPlusWCF.BLL
{
    public class DataFromRole : IDataFromRole
    {
        IUserMapper mapper;
        IUserDataService userDataService;
        IAdminDataService adminDataService;

        public DataFromRole(IUserMapper mapper, IUserDataService userDataService, IAdminDataService adminDataService)
        {
            this.mapper = mapper;
            this.userDataService = userDataService;
            this.adminDataService = adminDataService;
        }

        async Task<object> GetUsers<T>(IUsersDataByRole<T> dataService, String deleteUserLogin = null) where T : IUsersTable
        {
            var users = await mapper.GetAllUsersAsync();
            if (deleteUserLogin != null)
            {
                var currentUser = users.First(x => x.Login == deleteUserLogin);
                if (currentUser != null)
                {
                    users.Remove(currentUser);
                }
            }

            return dataService.GetUsers(users);
        }

        public async Task<object> GetUserDataFromUsers()
        {
            return new { data = await GetUsers(userDataService, HttpContext.Current.User.Identity.Name) };
        }

        public async Task<object> GetAdminDataFromUsers()
        {
            return new { data = await GetUsers(adminDataService) };
        }
    }
}