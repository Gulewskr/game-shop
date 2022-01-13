using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class GameByPlat
    {
        public int Id { get; set; }
        public int GameID { get; set; }
        public int PlatformID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AmountEnable { get; set; }
        public int AmountReserved { get; set; }
    }
}
