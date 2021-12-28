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
    public class DevelopersController : Controller
    {
        private readonly IDeveloperService _developerService;

        public DevelopersController(IDeveloperService service)
        {
            _developerService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            String z = "WoW Mega";
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            String z = "WoW Mega id " + id;
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add(/* [FromBody] CreateDeveloper developer */)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(/* [FromBody] CreateDeveloper developer ,*/ int id)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return NoContent();
        }
    }
}
