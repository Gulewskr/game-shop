using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface ICartRepository
    {
        Task UpdataeAsync(Cart o);
        Task AddAsync(Cart o);
        Task DelAsync(int id);
        Task<Cart> GetAsync(int id);
        Task<IEnumerable<Cart>> BrowseAllAsync();
        Task<Cart> GetUserCart(int id);
    }
}
