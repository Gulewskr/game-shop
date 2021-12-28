using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int GameID { get; set; }
        public int CartID { get; set; }
    }
}
