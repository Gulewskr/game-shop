using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateGame
    {
        //props
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        //FK
        public int CategoryID { get; set; }
        public int PublisherID { get; set; }
        public int DeveloperID { get; set; }
    }
}