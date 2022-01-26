using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> UploadFiles(IFormFile File, string pathToSave);
    }
}
