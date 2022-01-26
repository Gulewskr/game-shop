using gameshop.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class ImageService : IImageService
    {
        private static Random random = new Random();
        public async Task<string> UploadFiles(IFormFile file, string pathToSave)
        {
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "../GImages");
            if (file.Length > 0)
            {
                var fileName = RandomString(48) + ".png";
                //dodać sprawdzenie czy już taki nie istnieje
                string fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine("Images/", fileName);
                using (FileStream fs = System.IO.File.Create(fullPath))
                {
                    await file.CopyToAsync(fs);
                }
                //await _hubContext.Clients.All.SendAsync("Image", dbPath);
                return dbPath;
            }
            return null;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
