using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public DateTime BornDate { get; set; }
    }
}
