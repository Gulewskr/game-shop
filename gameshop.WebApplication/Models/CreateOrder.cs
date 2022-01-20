using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class CreateOrder
    {
        public int Amount { get; set; }
        public int GameID { get; set; }
        public int CartID { get; set; }
    }
}
