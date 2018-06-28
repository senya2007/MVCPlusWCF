using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserService.DAL.Db;
using UserService.Helper;
using UserService.Models;

namespace UserService.Mappers
{
    public class UserMapper : IUserMapper
    {
        IUserContext db;

        public UserMapper(IUserContext context)
        {
            this.db = context;
        }

        public bool CreateUser(User user)
        {
            bool result = false;
            try
            {
                user.Password = HashHelper.HashPassword(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                result = true;
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public bool DeleteUser(User user)
        {
            bool result = false;
            try
            {
                var deleteUser = db.Users.First(x => x.Id == user.Id);
                if (deleteUser != null)
                {
                    db.Users.Remove(deleteUser);
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        public List<User> GetAllUsers()
        {
            List<User> returnUsers = null;

            try
            {
                returnUsers = db.Users.ToList();
            }
            catch (Exception e)
            {

            }

            return returnUsers;
        }

        public void EditUser(User user)
        {
            try
            {
                user.Password = HashHelper.HashPassword(user.Password);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }

        public bool IsUserAuthentication(string login, string password)
        {
            bool result = false;
            var user = GetUserByLogin(login);
            if (user != null)
            {
                result = HashHelper.VerifyHashedPassword(user.Password, password);
            }

            return result;
        }

        public User GetUserByLogin(string login)
        {
            var query = $"SELECT * FROM [UserContext].[dbo].[User] WHERE Login = '{login}'";
            return db.Database.SqlQuery<User>(query).First();
        }
    }
}