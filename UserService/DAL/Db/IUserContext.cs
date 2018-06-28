using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UserService.Models;

namespace UserService.DAL.Db
{
    public class IUserContext : DbContext
    {
        public IUserContext(String connectionString)
            : base(connectionString)
        { }

        public DbSet<User> Users { get; set; }
    }
}