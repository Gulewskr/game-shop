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
    public class PlatformController : Controller
    {
        private readonly IPlatformService _service;

        public PlatformController(IPlatformService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<PlatformDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PlatformDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePlatform platform)
        {
            await _service.Add(new PlatformDTO()
            {
                Name = platform.Name,
                ImgSrc = platform.ImgSrc
            });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreatePlatform platform, int id)
        {
            await _service.Update(new PlatformDTO()
            {
                Id = id,
                Name = platform.Name,
                ImgSrc = platform.ImgSrc
            });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
