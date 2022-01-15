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
    public class GamePlatformController : Controller
    {
        private readonly IGameByPlatService _service;

        public GamePlatformController(IGameByPlatService service)
        {
            _service = service;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<GamePlatformDTO> z = await _service.GetAll();
            return Json(z);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GamePlatformDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetByFilter(int id)
        {
            IEnumerable<GamePlatformDTO> z = await _service.GetGame(id);
            return Json(z);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameBP game)
        {
            if(game.Id != 0)
            { 
                await _service.Update(new GamePlatformDTO()
                {
                    Id = game.Id,
                    ReleaseDate = game.ReleaseDate,
                    AmountEnable = game.AmountEnable,
                    AmountReserved = game.AmountReserved,
                    GameID = game.GameID,
                    PlatformID = game.PlatformID
                });
            }
            else
            {
                await _service.Add(new GamePlatformDTO()
                {
                    ReleaseDate = game.ReleaseDate,
                    AmountEnable = game.AmountEnable,
                    AmountReserved = game.AmountReserved,
                    GameID = game.GameID,
                    PlatformID = game.PlatformID
                });
            }
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateGameBP game, int id)
        {
            await _service.Update(new GamePlatformDTO()
            {
                Id = id,
                ReleaseDate = game.ReleaseDate,
                AmountEnable = game.AmountEnable,
                AmountReserved = game.AmountReserved,
                GameID = game.GameID,
                PlatformID = game.PlatformID
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
