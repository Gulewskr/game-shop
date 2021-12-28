using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IOrderRepository
    {
        Task UpdataeAsync(Order o);
        Task AddAsync(Order o);
        Task DelAsync(int id);
        Task<Order> GetAsync(int id);
        Task<IEnumerable<Order>> BrowseAllAsync();
    }
}
