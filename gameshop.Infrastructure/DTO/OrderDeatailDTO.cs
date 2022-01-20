using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.DTO
{
    public class OrderDeatailDTO
    {
        public int Id { get; set; }
        public int CartID { get; set; }

        //dane gry
        public int GameID { get; set; }
        public string Game_Name { get; set; }
        public string Game_ImageURL { get; set; }

        //dane platformy
        public int PlatformID { get; set; }
        public string Platform_Name { get; set; }
        public string Platform_ImgSrc { get; set; }

        //edytowalne przez użytkownika
        public int Amount { get; set; }
    }
}
