using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private AppDbContext _appDbContext;
        public DeveloperRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Developer o)
        {
            try
            {
                _appDbContext.Developers.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Developer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Developers);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Developers.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Developer> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Developers.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Developer o)
        {
            try
            {
                var z = _appDbContext.Developers.FirstOrDefault(x => x.Id == o.Id);
                z.Name = o.Name;
                z.EMail = o.EMail;
                z.Country = o.Country;
                z.City = o.City;
                z.Address = o.Address;
                z.ImageURL = o.ImageURL;
            
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
