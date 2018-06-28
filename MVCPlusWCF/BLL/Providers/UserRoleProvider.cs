using MVCPlusWCF.Exceptions;
using MVCPlusWCF.Mappers;
using MVCPlusWCF.ServiceMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVCPlusWCF.BLL.Providers
{
    public class UserRoleProvider : RoleProvider
    {
        IUserMapper mapper;
        static Dictionary<string, string> userRoleDictionary;

        public UserRoleProvider()
        {
            this.mapper = new UserMapper();
        }

        static UserRoleProvider()
        {
            userRoleDictionary = new Dictionary<string, string>();
        }

        public UserRoleProvider(IUserMapper mapper)
        {
            this.mapper = mapper;
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            try
            {
                if (userRoleDictionary.ContainsKey(usernames[0]))
                {
                    userRoleDictionary[usernames[0]] = roleNames[0];
                }
                else
                {
                    userRoleDictionary.Add(usernames[0], roleNames[0]);
                }
            }
            catch (Exception e)
            {
                MvcApplication.logger.Error(e.InnerException, "Ошибка в методе AddUsersToRoles");
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            if (userRoleDictionary.ContainsKey(username))
            {
                string[] result = { userRoleDictionary[username] };
                return result;
            }
            else
            {
                MvcApplication.logger.Error($"Ошибка в методе GetRolesForUser, {username} не найден");
                throw new RoleNotFoundException();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            List<string> arrayUsers = new List<string>();
            foreach (var userRoleKeyValuePair in userRoleDictionary)
            {
                if (userRoleKeyValuePair.Value == roleName)
                {
                    arrayUsers.Add(userRoleKeyValuePair.Key);
                }
            }

            return arrayUsers.ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool result = false;
            if (userRoleDictionary.ContainsKey(username))
            {
                if (userRoleDictionary[username] == roleName)
                {
                    result = true;
                }
            }
            return result;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var user in usernames)
            {
                if (userRoleDictionary.ContainsKey(user))
                {
                    userRoleDictionary.Remove(user);
                }
            }
        }

        public override bool RoleExists(string roleName)
        {
            return userRoleDictionary.ContainsValue(roleName);
        }
    }
}