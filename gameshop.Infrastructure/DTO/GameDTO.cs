using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int DeveloperID { get; set; }
    }
}