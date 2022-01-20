using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public enum OrderStatus { Ongoing, Canceled, Ended }
    public class CartVM
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastChange { get; set; }
        public string UserID { get; set; }
    }
}
