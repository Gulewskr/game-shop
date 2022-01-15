using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface ICartService
    {
        Task<IEnumerable<CartDTO>> GetAll();
        Task<CartDTO> Get(int id);
        Task Add(CartDTO o);
        Task Update(CartDTO o);
        Task Delete(int id);
        Task<CartDTO> GetUserCart(int id);
    }
}
