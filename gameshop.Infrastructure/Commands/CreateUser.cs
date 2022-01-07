using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateUser
    {
        public string UserId { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public DateTime BornDate { get; set; }
    }
}
