﻿using gameshop.Infrastructure.Commands;
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
    public class GamePlatformController : Controller
    {
        private readonly IGameByPlatService _service;

        public GamePlatformController(IGameByPlatService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<GamePlatformDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            GamePlatformDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameBP game)
        {
            await _service.Add(new GamePlatformDTO()
            {
                ReleaseDate = game.ReleaseDate,
                AmountEnable = game.AmountEnable,
                AmountReserved = game.AmountReserved,
                GameID = game.GameID,
                PlatformID = game.PlatformID
            });
            return NoContent();
        }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}