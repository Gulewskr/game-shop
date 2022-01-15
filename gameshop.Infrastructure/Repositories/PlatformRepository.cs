using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        private AppDbContext _appDbContext;
        public PlatformRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Platform o)
        {
            try
            {
                _appDbContext.Platforms.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Platform>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Platforms);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Platforms.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Platform> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Platforms.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Platform o)
        {
            try
            {
                var z = _appDbContext.Platforms.FirstOrDefault(x => x.Id == o.Id);
                z.ImageURL = o.ImageURL;
                z.Name = o.Name;

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
