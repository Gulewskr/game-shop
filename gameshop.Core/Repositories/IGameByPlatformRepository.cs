using gameshop.Core.Domain;
using gameshop.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IGameByPlatformRepository
    {
        Task UpdataeAsync(GameByPlatformSpec o);
        Task AddAsync(GameByPlatformSpec o);
        Task DelAsync(int id);
        Task<GameByPlatformSpec> GetAsync(int id);
        Task<GameDetailsDTO> GetDetailedAsync(int id);
        Task<IEnumerable<GameByPlatformSpec>> BrowseAllAsync();
        Task<IEnumerable<GameByPlatformSpec>> GetByGame(int id);
    }
}
