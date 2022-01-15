using gameshop.Infrastructure.Commands;
using gameshop.Infrastructure.DTO;
using gameshop.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        private readonly IPublisherService _service;

        public PublisherController(IPublisherService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<PublisherDTO> z = await _service.GetAll();
            return Json(z);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PublisherDTO z = await _service.Get(id);
            return Json(z);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCompany publisher)
        {
            await _service.Add(new PublisherDTO()
            {
                Name = publisher.Name,
                EMail = publisher.EMail,
                Country = publisher.Country,
                City = publisher.City,
                Address = publisher.Address
            });
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateCompany publisher, int id)
        {
            await _service.Update(new PublisherDTO()
            {
                Id = id,
                Name = publisher.Name,
                EMail = publisher.EMail,
                Country = publisher.Country,
                City = publisher.City,
                Address = publisher.Address
            });
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
