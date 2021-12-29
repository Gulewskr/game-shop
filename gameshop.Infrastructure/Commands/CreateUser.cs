using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateUser
    {
        public string Login { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public DateTime BornDate { get; set; }
    }
}
