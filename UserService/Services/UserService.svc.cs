using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UserService.Helper.Services;
using UserService.Mappers;
using UserService.Models;

namespace UserService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class UserService : IUserService
    {
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        IUserMapper mapper;
        IAuthentication authenticationService;

        public UserService(IUserMapper mapper, IAuthentication authenticationService)
        {
            this.mapper = mapper;
            this.authenticationService = authenticationService;
        }

        public bool CreateUser(User user)
        {
            bool result = false;
            try
            {
                result = mapper.CreateUser(user);
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при создании пользователя");
                result = false;
            }
            return result;
        }

        public bool DeleteUser(User user)
        {
            bool result = false;
            try
            {
                result = mapper.DeleteUser(user);
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при удалении пользователя");
                result = false;
            }
            return result;
        }

        public List<User> GetAllUsers()
        {
            List<User> returnUsers = null;

            try
            {
                returnUsers = mapper.GetAllUsers();
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при поличении пользователей");
            }

            return returnUsers;
        }

        public void EditUser(User user)
        {
            try
            {
                mapper.EditUser(user);
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при редактировании пользователя");
            }
        }

        public bool IsUserAuthentication(string login, string password)
        {
            try
            {
                return authenticationService.IsUserAuthentication(login, password);
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при аутентификации пользователя");
            }
            return false;
        }

        public User GetUserByLogin(string login)
        {
            try
            {
                return mapper.GetUserByLogin(login);
            }
            catch (Exception e)
            {
                logger.Error(e.InnerException, "Ошибка при получении пользователя с помощью логина");
            }
            return null;
        }
    }
}
