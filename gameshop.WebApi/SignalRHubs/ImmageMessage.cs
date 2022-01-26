using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApi.SignalRHubs
{
    public class ImageMessage
    {
        public byte[] ImageBinary { get; set; }
        public string ImageHeaders { get; set; }
    }
}
