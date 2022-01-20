using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Core.Domain.DTO;
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
        public async Task<GameDetailsDTO> GetDetailedAsync(int id)
        {
            var g = await Task.FromResult(_appDbContext.GamesByPlatform.FirstOrDefault(x => x.Id == id));
            if(g != null)
            {
                var game = await Task.FromResult(_appDbContext.Games.FirstOrDefault(x => x.Id == g.GameID));
                var platform = await Task.FromResult(_appDbContext.Platforms.FirstOrDefault(x => x.Id == g.PlatformID));
                return new GameDetailsDTO()
                {
                    Id = g.Id,
                    ReleaseDate = g.ReleaseDate,
                    GameID = game.Id,
                    Game_ImageURL = game.ImageURL,
                    Game_Name = game.Name,
                    PlatformID = platform.Id,
                    Platform_ImgSrc = platform.ImageURL,
                    Platform_Name = platform.Name
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<GameByPlatformSpec>> GetByGame(int id)
        {
            return await Task.FromResult(_appDbContext.GamesByPlatform.Where(x => x.GameID == id));
        }

        public async Task UpdataeAsync(GameByPlatformSpec o)
        {
            try
            {
                Console.WriteLine($"{o.Id} {o.GameID} {o.Platform} {o.AmountEnable} {o.AmountReserved}");
                _appDbContext.GamesByPlatform.Update(o);
                /*
                 * var z = _appDbContext.GamesByPlatform.FirstOrDefault(x => x.Id == o.Id);
                //z.GameID = o.GameID;
                z.AmountEnable = o.AmountEnable;
                z.AmountReserved = o.AmountReserved;
                //z.PlatformID = o.PlatformID;
                z.ReleaseDate = o.ReleaseDate;
                */
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
