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
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<UserDTO> z = await _service.GetAll();
            return Json(z);
        }
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUser user)
        {
            System.Diagnostics.Debug.WriteLine(user.UserId);
            await _service.Add(new UserDTO()
            {
                UserId = user.UserId,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                Phonenumber = user.Phonenumber,
                BornDate = user.BornDate
            });
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateUser user, int id)
        {
            await _service.Update(new UserDTO()
            {
                Id = id,
                UserId = user.UserId,
                Forename = user.Forename,
                Surname = user.Surname,
                Email = user.Email,
                Phonenumber = user.Phonenumber,
                BornDate = user.BornDate
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
