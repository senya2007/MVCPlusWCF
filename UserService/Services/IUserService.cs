using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using UserService.Models;

namespace UserService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        bool CreateUser(User user);
        [OperationContract]
        void EditUser(User user);
        [OperationContract]
        bool DeleteUser(User user);
        [OperationContract]
        List<User> GetAllUsers();
        [OperationContract]
        bool IsUserAuthentication(string login, string password);
        [OperationContract]
        User GetUserByLogin(string login);
    }
}
