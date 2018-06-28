using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MVCPlusWCF.Models;

namespace MVCPlusWCF.ServiceMappers
{
    public interface IUserMapper
    {
        Task<bool> CreateUserAsync(User user);
        Task EditUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByLoginAsync(string login);
    }
}