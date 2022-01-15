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
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PasswordController : Controller
    {
        private readonly IPasswordService _service;

        public PasswordController(IPasswordService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<PasswordDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PasswordDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePassword pass)
        {
            await _service.Add(new PasswordDTO()
            {
                Salt = pass.Salt,
                HashedPassword = pass.HashedPassword,
                UserID = pass.UserID
            });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreatePassword pass, int id)
        {
            await _service.Update(new PasswordDTO()
            {
                Id = id,
                Salt = pass.Salt,
                HashedPassword = pass.HashedPassword,
                UserID = pass.UserID
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
