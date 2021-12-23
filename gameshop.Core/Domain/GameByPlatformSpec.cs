using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace gameshop.Core.Domain
{
    public class GameByPlatformSpec
    {
        public int Id { get; set; }
        
        public int GameID { get; set; }
        [ForeignKey("GameID")]
        public Game Game { get; set; }
        
        public int PlatformID { get; set; }
        [ForeignKey("PlatformID")]
        public Platform Platform { get; set; }

        public DateTime ReleaseDate { get; set; }
        public int AmountEnable { get; set; }
        public int AmountReserved { get; set; }
    }
}
