using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private AppDbContext _appDbContext;
        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Game o)
        {
            try
            {
                _appDbContext.Games.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Game>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Games);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Games.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Game> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Games.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Game o)
        {
            try
            { 
                //_appDbContext.Games.Update(o);
                var z = _appDbContext.Games.FirstOrDefault(x => x.Id == o.Id);
                z.Name = o.Name;
                z.Description = o.Description;
                z.ImageURL = o.ImageURL;
                z.CategoryID = o.CategoryID;
                z.DeveloperID = o.DeveloperID;
                z.PublisherID = o.PublisherID;
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
