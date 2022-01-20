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
        private readonly IGameByPlatformRepository gameRepository;
        public OrderService(IOrderRepository repository, IGameByPlatformRepository repository2)
        {
            orderRepository = repository;
            gameRepository = repository2;
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

        public async Task<IEnumerable<OrderDeatailDTO>> GetByCartID(int id)
        {
            var z = await orderRepository.GetByCartIDAsync(id);
            if (z.ToList().Count == 0) return new List<OrderDeatailDTO>();
            var x = await Task.WhenAll(z.Select(async(order) =>  {
                if (order == null) return new OrderDeatailDTO();
                var g = await gameRepository.GetDetailedAsync(order.GameID);
                if (g == null) return new OrderDeatailDTO();
                return new OrderDeatailDTO()
                {
                    Id = order.Id,
                    Amount = order.Amount,
                    CartID = order.CartID,
                    GameID = g.GameID,
                    Game_ImageURL = g.Game_ImageURL,
                    Game_Name = g.Game_Name,
                    PlatformID = g.PlatformID,
                    Platform_Name = g.Platform_Name,
                    Platform_ImgSrc = g.Platform_ImgSrc
                };
            }));
            return x;
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
