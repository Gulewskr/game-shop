using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class CartDTO
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChange { get; set; }
        public int UserID { get; set; }
    }
}
