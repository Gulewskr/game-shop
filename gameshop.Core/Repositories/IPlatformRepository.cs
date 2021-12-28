using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IPlatformRepository
    {
        Task UpdataeAsync(Platform o);
        Task AddAsync(Platform o);
        Task DelAsync(int id);
        Task<Platform> GetAsync(int id);
        Task<IEnumerable<Platform>> BrowseAllAsync();
    }
}
