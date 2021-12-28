using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class GameByPlatformRepository : IGameByPlatformRepository
    {
        private AppDbContext _appDbContext;
        public GameByPlatformRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(GameByPlatformSpec o)
        {
            try
            {
                _appDbContext.GamesByPlatform.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<GameByPlatformSpec>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.GamesByPlatform);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.GamesByPlatform.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<GameByPlatformSpec> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.GamesByPlatform.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(GameByPlatformSpec o)
        {
            try
            {
                var z = _appDbContext.GamesByPlatform.FirstOrDefault(x => x.Id == o.Id);
                z.GameID = o.GameID;
                z.AmountEnable = o.AmountEnable;
                z.AmountReserved = o.AmountReserved;
                z.PlatformID = o.PlatformID;
                z.ReleaseDate = o.ReleaseDate;

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
