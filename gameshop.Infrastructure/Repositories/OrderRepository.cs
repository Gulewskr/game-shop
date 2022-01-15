using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _appDbContext;
        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Order o)
        {
            try
            {
                _appDbContext.Orders.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Order>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Orders);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Orders.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Order> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Orders.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Order>> GetByCartIDAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Orders.Where(x => x.CartID == id));
        }

        public async Task UpdataeAsync(Order o)
        {
            try
            {
                var z = _appDbContext.Orders.FirstOrDefault(x => x.Id == o.Id);
                z.Amount = o.Amount;
                z.GameID = o.GameID;
                z.CartID = o.CartID;
          
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }
    }
}
