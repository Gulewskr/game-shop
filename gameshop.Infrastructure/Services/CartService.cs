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
    public class CartService : ICartService
    {
        private readonly ICartRepository cartRepository;
        public CartService(ICartRepository repository)
        {
            cartRepository = repository;
        }
        public async Task Add(CartDTO cart)
        {
            if (cart == null) throw new ArgumentNullException("coach must have value");
            await cartRepository.AddAsync(new Cart()
            {
                CreateTime = cart.CreateTime,
                LastChange = cart.LastChange,
                Status = cart.Status,
                UserID = cart.UserID,
            });
            return;
        }

        public async Task Delete(int id)
        {
            await cartRepository.DelAsync(id);
            return;
        }

        public async Task<CartDTO> Get(int id)
        {
            var z = await cartRepository.GetAsync(id);
            if (z == null) return null;
            return new CartDTO()
            {
                Id = z.Id,
                CreateTime = z.CreateTime,
                LastChange = z.LastChange,
                Status = z.Status,
                UserID = z.UserID,
            };
        }

        public async Task<IEnumerable<CartDTO>> GetAll()
        {
            var z = await cartRepository.BrowseAllAsync();
            return z.Select(z => new CartDTO()
            {
                Id = z.Id,
                CreateTime = z.CreateTime,
                LastChange = z.LastChange,
                Status = z.Status,
                UserID = z.UserID
            });
        }

        public async Task Update(CartDTO cart)
        {
            if (cart == null) throw new ArgumentNullException("developer must have value");
            await cartRepository.UpdataeAsync(new Cart()
            {
                Id = cart.Id,
                CreateTime = cart.CreateTime,
                LastChange = cart.LastChange,
                Status = cart.Status,
                UserID = cart.UserID
            });
            return;
        }
    }
}
