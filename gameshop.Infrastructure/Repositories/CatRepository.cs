using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class CatRepository : ICartRepository
    {
        private AppDbContext _appDbContext;
        public CatRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Cart o)
        {
            try
            {
                _appDbContext.Carts.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task AddOrderAsync(Order order)
        {
            try
            {
                _appDbContext.Orders.Add(order);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Cart>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Carts);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Carts.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Cart> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Carts.FirstOrDefault(x => x.Id == id));
        }

        public async Task<Cart> GetUserCart(string id)
        {
            try
            {
                var c = _appDbContext.Carts.FirstOrDefault(x => x.UserID == id && x.Status == OrderStatus.Ongoing);
                if (c == null)
                {
                    await AddAsync(new Cart()
                    {
                        Status = OrderStatus.Ongoing,
                        CreateTime = DateTime.Now,
                        LastChange = DateTime.Now,
                        UserID = id
                    });
                    c = _appDbContext.Carts.FirstOrDefault(x => x.UserID == id && x.Status == OrderStatus.Ongoing);
                }
                return await Task.FromResult(c);
            }catch (Exception e)
            {
                return null;
            }
        }

        public async Task UpdataeAsync(Cart o)
        {
            try
            {
                var z = _appDbContext.Carts.FirstOrDefault(x => x.Id == o.Id);
                z.CreateTime = o.CreateTime;
                z.LastChange = o.LastChange;
                z.Status = o.Status;
                z.UserID = o.UserID;

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
