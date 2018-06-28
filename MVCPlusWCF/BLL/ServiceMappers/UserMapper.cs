using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MVCPlusWCF.Models;
using MVCPlusWCF.ServiceMappers;

namespace MVCPlusWCF.Mappers
{
    public class UserMapper : IUserMapper
    {
        MVCPlusWCF.UserService.IUserService service;

        public UserMapper()
        {
            service = new MVCPlusWCF.UserService.UserServiceClient();
        }

        public UserMapper(MVCPlusWCF.UserService.IUserService service)
        {
            this.service = service;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            bool result = false;
            try
            {
               result = await service.CreateUserAsync(ConvertUserToUserService(user));
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            bool result = false;
            try
            {
                  result = await service.DeleteUserAsync(ConvertUserToUserService(user));
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            List<User> returnUsers = new List<User>();

            var serviceUsers = await service.GetAllUsersAsync();
            foreach (var serviceUser in serviceUsers)
            {
                returnUsers.Add(ConvertServiceUserToUser(serviceUser));
            }

            return returnUsers;
        }

        public async Task EditUserAsync(User user)
        {
           await service.EditUserAsync(ConvertUserToUserService(user));
        }

        public async Task<User> GetUserByLoginAsync(string login)
        {
            return ConvertServiceUserToUser(await service.GetUserByLoginAsync(login));
        }

        public User ConvertServiceUserToUser(UserService.User serviceUser)
        {
            return new User
            {
                Id = serviceUser.Id,
                Login = serviceUser?.Login,
                Name = serviceUser?.Name,
                Password = serviceUser?.Password,
                Patronymic = serviceUser?.Patronymic,
                Phone = serviceUser?.Phone,
                Role = serviceUser.Role == UserService.Role.Admin ? Role.Admin : Role.User,
                Surname = serviceUser?.Surname
            };
        }

        private UserService.User ConvertUserToUserService(User user)
        {
            return new UserService.User
            {
                Id = user.Id,
                Login = user?.Login,
                Name = user?.Name,
                Password = user?.Password,
                Patronymic = user?.Patronymic,
                Phone = user?.Phone,
                Role = user.Role == Role.Admin ? UserService.Role.Admin : UserService.Role.User,
                Surname = user?.Surname
            };
        }
    }
}