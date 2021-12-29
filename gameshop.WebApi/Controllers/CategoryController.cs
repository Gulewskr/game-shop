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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CategoryDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CategoryDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateWithName category)
        {
            await _service.Add(new CategoryDTO()
            {
                Name = category.Name
            });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateWithName category, int id)
        {
            await _service.Update(new CategoryDTO()
            {
                Id = id,
                Name = category.Name
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
