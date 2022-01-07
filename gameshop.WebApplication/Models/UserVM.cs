using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public DateTime BornDate { get; set; }
    }
}
