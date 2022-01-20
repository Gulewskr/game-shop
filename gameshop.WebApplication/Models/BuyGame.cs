using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class BuyGame
    {
        public int GameID { get; set; }
        public string UserID { get; set; }
        public int amount { get; set; }
    }
}
