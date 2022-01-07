using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "User name is required!")]
        [Display(Name = "User name")]
        public string Login { get; set; }
        [Required(ErrorMessage = "User password is required!")]
        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public DateTime BornDate { get; set; }
    }
}
