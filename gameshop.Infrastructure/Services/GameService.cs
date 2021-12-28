using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
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
        public Task Add(GameDTO game)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GameDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GameDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(GameDTO game)
        {
            throw new NotImplementedException();
        }
    }
}
