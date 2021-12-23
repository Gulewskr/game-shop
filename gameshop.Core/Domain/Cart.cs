using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Core.Domain
{
    public enum OrderStatus { Ongoing, Canceled, Ended }

    public class Cart
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChange { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
