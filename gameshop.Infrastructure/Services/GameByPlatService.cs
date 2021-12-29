using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class GameByPlatService : IGameByPlatService
    {
        private readonly IGameByPlatformRepository gameRepository;
        public GameByPlatService(IGameByPlatformRepository repository)
        {
            gameRepository = repository;
        }
        public async Task Add(GamePlatformDTO game)
        {
            if (game == null) throw new ArgumentNullException("coach must have value");
            await gameRepository.AddAsync(new GameByPlatformSpec()
            {
                GameID = game.GameID,
                AmountEnable = game.AmountEnable,
                AmountReserved = game.AmountReserved,
                PlatformID = game.PlatformID,
                ReleaseDate = game.ReleaseDate
            });
            return;
        }

        public async Task Delete(int id)
        {
            await gameRepository.DelAsync(id);
            return;
        }

        public async Task<GamePlatformDTO> Get(int id)
        {
            var z = await gameRepository.GetAsync(id);
            if (z == null) return null;
            return new GamePlatformDTO()
            {
                Id = z.Id,
                GameID = z.GameID,
                AmountEnable = z.AmountEnable,
                AmountReserved = z.AmountReserved,
                PlatformID = z.PlatformID,
                ReleaseDate = z.ReleaseDate
            };
        }

        public async Task<IEnumerable<GamePlatformDTO>> GetAll()
        {
            var z = await gameRepository.BrowseAllAsync();
            return z.Select(game => new GamePlatformDTO()
            {
                Id = game.Id,
                GameID = game.GameID,
                AmountEnable = game.AmountEnable,
                AmountReserved = game.AmountReserved,
                PlatformID = game.PlatformID,
                ReleaseDate = game.ReleaseDate
            });
        }

        public async Task Update(GamePlatformDTO game)
        {
            if (game == null) throw new ArgumentNullException("developer must have value");
            await gameRepository.UpdataeAsync(new GameByPlatformSpec()
            {
                Id = game.Id,
                GameID = game.GameID,
                AmountEnable = game.AmountEnable,
                AmountReserved = game.AmountReserved,
                PlatformID = game.PlatformID,
                ReleaseDate = game.ReleaseDate
            });
            return;
        }
    }
}
