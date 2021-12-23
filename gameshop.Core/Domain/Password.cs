using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Core.Domain
{
    public class Password
    {
        public int Id { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
