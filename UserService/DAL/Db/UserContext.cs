using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using UserService.DAL.Db;
using UserService.Models;

namespace UserService.DAL.Db
{
    public class UserContext : IUserContext
    {
        public UserContext()
            :base("UserContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}