using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository repository)
        {
            cartRepository = repository;
        }
        public Task Add(CartDTO cart)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CartDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CartDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(CartDTO cart)
        {
            throw new NotImplementedException();
        }
    }
}
