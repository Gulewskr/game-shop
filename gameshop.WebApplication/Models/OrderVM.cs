using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApplication.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public int GameID { get; set; }
        public int CartID { get; set; }
        public int PlatformID { get; set; }
        
        //dane gry
        public string Game_Name { get; set; }
        public string Game_ImageURL { get; set; }

        //dane platformy
        public string Platform_Name { get; set; }
        public string Platform_ImgSrc { get; set; }
        
        //edytowalne przez użytkownika
        public int Amount { get; set; }
    }
}
