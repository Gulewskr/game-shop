using gameshop.Infrastructure.Commands;
using gameshop.Infrastructure.DTO;
using gameshop.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gameshop.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _service;

        public CartController(ICartService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CartDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CartDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpGet("user-{id}")]
        public async Task<IActionResult> GetUserCart(string id)
        {
            CartDTO z = await _service.GetUserCart(id);
            return Json(z);
        }

        private async Task<int> GetUserCartID(string id)
        {
            CartDTO z = await _service.GetUserCart(id);
            return z.Id;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCart cart)
        {
            await _service.Add(new CartDTO()
            {
                CreateTime = cart.CreateTime,
                LastChange = cart.LastChange,
                Status = (Core.Domain.OrderStatus) cart.Status,
                UserID = cart.UserID
            });
            return NoContent();
        }

        [HttpPost("AddToCart")]
        public async Task<IActionResult> Add([FromBody] BuyGame game)
        {
            int cartId = await GetUserCartID(game.UserID);
            await _service.AddOrder(new OrderDTO()
            {
                Amount = game.amount,
                GameID = game.GameID,
                CartID = cartId,
            });
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateCart cart, int id)
        {
            await _service.Update(new CartDTO()
            {
                Id = id,
                CreateTime = cart.CreateTime,
                LastChange = cart.LastChange,
                Status = (Core.Domain.OrderStatus)cart.Status,
                UserID = cart.UserID
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
