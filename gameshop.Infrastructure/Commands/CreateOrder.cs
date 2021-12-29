using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateOrder
    {
        public int Amount { get; set; }
        public int GameID { get; set; }
        public int CartID { get; set; }
    }
}
