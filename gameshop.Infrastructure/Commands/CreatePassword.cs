using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreatePassword
    {
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public int UserID { get; set; }
    }
}