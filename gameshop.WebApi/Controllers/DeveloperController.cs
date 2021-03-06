using gameshop.Infrastructure.Commands;
using gameshop.Infrastructure.DTO;
using gameshop.Infrastructure.Services;
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
    public class DeveloperController : Controller
    {
        private readonly IDeveloperService _developerService;

        public DeveloperController(IDeveloperService service)
        {
            _developerService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<DeveloperDTO> z = await _developerService.GetAll();
            return Json(z);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DeveloperDTO z = await _developerService.Get(id);
            return Json(z);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCompany developer)
        {
            //string imgUrl = await _serviceImages.UploadFiles(developer.File, Path.Combine(Directory.GetCurrentDirectory(), "Images"));
            await _developerService.Add(new DeveloperDTO()
            {
                Name = developer.Name,
                EMail = developer.EMail,
                Country = developer.Country,
                City = developer.City,
                Address = developer.Address,
                ImageURL = developer.ImageURL
            });
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateCompany developer, int id)
        {
            await _developerService.Update(new DeveloperDTO()
            {
                Id = id,
                Name = developer.Name,
                EMail = developer.EMail,
                Country = developer.Country,
                City = developer.City,
                Address = developer.Address
            });
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _developerService.Delete(id);
            return NoContent();
        }
    }
}
