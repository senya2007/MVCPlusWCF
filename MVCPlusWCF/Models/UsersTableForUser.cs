using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCPlusWCF.Models
{
    public class UsersTableForUser : IUsersTable
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
    }
}