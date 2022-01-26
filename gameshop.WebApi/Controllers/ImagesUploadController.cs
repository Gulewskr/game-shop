using gameshop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImagesUploadController : Controller
    {
        private readonly IImageService _serviceImages;
        public ImagesUploadController(IImageService service2)
        {
            _serviceImages = service2;
        }
        
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(IFormFile image)
        {
            if(image != null)
            {
                string path  = await _serviceImages.UploadFiles(image, Path.Combine(Directory.GetCurrentDirectory(), "Images"));
                return Json(path);
            }
            else
            {
                return Json("Null");
            }

        }
    }
}
