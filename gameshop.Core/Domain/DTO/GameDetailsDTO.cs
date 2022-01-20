using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Core.Domain.DTO
{
    public class GameDetailsDTO
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int GameID { get; set; }
        public string Game_Name { get; set; }
        public string Game_ImageURL { get; set; }

        public int PlatformID { get; set; }
        public string Platform_Name { get; set; }
        public string Platform_ImgSrc { get; set; }
    }
}
