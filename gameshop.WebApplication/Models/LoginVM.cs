using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User name is required!")]
        [Display(Name = "User name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "User password is required!")]
        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
