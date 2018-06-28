using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCPlusWCF.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name="Логин")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Введите только латинские символы")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
    }
}