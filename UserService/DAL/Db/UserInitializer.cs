using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserService.Helper;
using UserService.Models;

namespace UserService.DAL.Db
{
    public class UserInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User{  Login = "admin",  Password = HashHelper.HashPassword("password"), Name="Иван", Surname = "Иванов", Patronymic = "Иванович", Phone = "+7(999)999-99-99", Role = Role.Admin}
            };

            users.ForEach(x => context.Users.Add(x));
            context.SaveChanges();
        }
    }
}