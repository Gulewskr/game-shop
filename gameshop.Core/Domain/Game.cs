using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Core.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public int PublisherID { get; set; }
        [ForeignKey("PublisherID")]
        public Publisher Publisher { get; set; }

        public int DeveloperID { get; set; }
        [ForeignKey("DeveloperID")]
        public Developer Developer { get; set; }}
}
