using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IGameRepository
    {
        Task UpdataeAsync(Game o);
        Task AddAsync(Game o);
        Task DelAsync(int id);
        Task<Game> GetAsync(int id);
        Task<IEnumerable<Game>> BrowseAllAsync();
    }
}
