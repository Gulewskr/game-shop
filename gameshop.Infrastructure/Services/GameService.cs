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
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;
        public GameService(IGameRepository repository)
        {
            gameRepository = repository;
        }
        public async Task Add(GameDTO game)
        {
            if (game == null) throw new ArgumentNullException("coach must have value");
            await gameRepository.AddAsync(new Game()
            {
                Name = game.Name,
                Description = game.Description,
                CategoryID = game.CategoryID,
                DeveloperID = game.DeveloperID,
                PublisherID = game.PublisherID,
                ImageURL = game.ImageURL
            });
            return;
        }

        public async Task Delete(int id)
        {
            await gameRepository.DelAsync(id);
            return;
        }

        public async Task<GameDTO> Get(int id)
        {
            var z = await gameRepository.GetAsync(id);
            if (z == null) return null;
            return new GameDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Description = z.Description,
                CategoryID = z.CategoryID,
                DeveloperID = z.DeveloperID,
                PublisherID = z.PublisherID,
                ImageURL = z.ImageURL
            };
        }

        public async Task<IEnumerable<GameDTO>> GetAll()
        {
            var z = await gameRepository.BrowseAllAsync();
            return z.Select(game => new GameDTO()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CategoryID = game.CategoryID,
                DeveloperID = game.DeveloperID,
                PublisherID = game.PublisherID,
                ImageURL = game.ImageURL
            });
        }

        public async Task Update(GameDTO game)
        {
            if (game == null) throw new ArgumentNullException("developer must have value");
            await gameRepository.UpdataeAsync(new Game()
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                CategoryID = game.CategoryID,
                DeveloperID = game.DeveloperID,
                PublisherID = game.PublisherID,
                ImageURL = game.ImageURL
            });
            return;
        }
    }
}
