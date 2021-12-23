using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Core.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        
        public int GameID { get; set; }
        [ForeignKey("GameID")]
        public Game Game { get; set; }

        public int CartID { get; set; }
        [ForeignKey("CartID")]
        public Cart Cart { get; set; }
    }
}
