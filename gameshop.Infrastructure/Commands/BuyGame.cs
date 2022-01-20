using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class BuyGame
    {
        public int GameID { get; set; }
        public string UserID { get; set; }
        public int amount { get; set; }
    }
}
