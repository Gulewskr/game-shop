using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateCart
    {
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChange { get; set; }
        public string UserID { get; set; }
    }
}
