using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IDeveloperRepository
    {
        Task UpdataeAsync(Developer o);
        Task AddAsync(Developer o);
        Task DelAsync(int id);
        Task<Developer> GetAsync(int id);
        Task<IEnumerable<Developer>> BrowseAllAsync();
    }
}
