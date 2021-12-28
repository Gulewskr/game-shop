using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
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
        public Task Add(OrderDTO order)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(OrderDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
