using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Core.Domain
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string EMail { get; set; }
        public string ImageURL { get; set; }
    }
}
