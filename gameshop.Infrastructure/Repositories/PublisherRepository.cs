using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private AppDbContext _appDbContext;
        public PublisherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Publisher o)
        {
            try
            {
                _appDbContext.Publishers.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Publisher>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Publishers);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Publishers.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Publisher> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Publishers.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Publisher o)
        {
            try
            {
                var z = _appDbContext.Publishers.FirstOrDefault(x => x.Id == o.Id);
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
