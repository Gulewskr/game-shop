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
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<OrderDTO> z = await _service.GetAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            OrderDTO z = await _service.Get(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrder order)
        {
            await _service.Add(new OrderDTO()
            {
                Amount = order.Amount,
                GameID = order.GameID,
                CartID = order.CartID,
            });
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CreateOrder order, int id)
        {
            await _service.Update(new OrderDTO()
            {
                Id = id,
                Amount = order.Amount,
                GameID = order.GameID,
                CartID = order.CartID,
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
