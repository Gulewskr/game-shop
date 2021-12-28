using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class PasswordDTO
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public int UserID { get; set; }
    }
}
