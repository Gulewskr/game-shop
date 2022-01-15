using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Commands
{
    public class CreateGameBP
    {
        public int Id { get; set; }
        public int GameID { get; set; }
        public int PlatformID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AmountEnable { get; set; }
        public int AmountReserved { get; set; }
    }
}
