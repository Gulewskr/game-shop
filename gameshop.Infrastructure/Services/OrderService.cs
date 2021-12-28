using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        public OrderService(IOrderRepository repository)
        {
            orderRepository = repository;
        }
        public async Task Add(OrderDTO order)
        {
            if (order == null) throw new ArgumentNullException("coach must have value");
            await orderRepository.AddAsync(new Order()
            {
                GameID = order.GameID,
                Amount = order.Amount,
                CartID = order.CartID
            });
            return;
        }

        public async Task Delete(int id)
        {
            await orderRepository.DelAsync(id);
            return;
        }

        public async Task<OrderDTO> Get(int id)
        {
            var z = await orderRepository.GetAsync(id);
            if (z == null) return null;
            return new OrderDTO()
            {
                Id = z.Id,
                GameID = z.GameID,
                Amount = z.Amount,
                CartID = z.CartID
            };
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var z = await orderRepository.BrowseAllAsync();
            return z.Select(order => new OrderDTO()
            {
                Id = order.Id,
                GameID = order.GameID,
                Amount = order.Amount,
                CartID = order.CartID
            });
        }

        public async Task Update(OrderDTO order)
        {
            if (order == null) throw new ArgumentNullException("developer must have value");
            await orderRepository.UpdataeAsync(new Order()
            {
                Id = order.Id,
                GameID = order.GameID,
                Amount = order.Amount,
                CartID = order.CartID
            });
            return;
        }
    }
}
