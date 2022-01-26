using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class GameCreate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int DeveloperID { get; set; }
        public string ImageURL { get; set; }
    }
}
