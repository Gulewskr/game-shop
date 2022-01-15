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
    public class GameController : Controller
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<GameDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GameDTO z = await _service.Get(id);
            return Json(z);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGame game)
        {
            await _service.Add(new GameDTO()
            {
                Name = game.Name,
                Description = game.Description,
                CategoryID = game.CategoryID,
                DeveloperID = game.DeveloperID,
                PublisherID = game.PublisherID
            });
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateGame game, int id)
        {
            await _service.Update(new GameDTO()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryID = game.CategoryID,
                DeveloperID = game.DeveloperID,
                PublisherID = game.PublisherID
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
