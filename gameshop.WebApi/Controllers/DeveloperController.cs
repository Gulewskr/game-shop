using gameshop.Infrastructure.Commands;
using gameshop.Infrastructure.DTO;
using gameshop.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            DeveloperDTO z = await _developerService.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCompany developer)
        {
            await _developerService.Add(new DeveloperDTO()
            {
                Name = developer.Name,
                EMail = developer.EMail,
                Country = developer.Country,
                City = developer.City,
                Address = developer.Address
            });
            return NoContent();
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _developerService.Delete(id);
            return NoContent();
        }
    }
}
