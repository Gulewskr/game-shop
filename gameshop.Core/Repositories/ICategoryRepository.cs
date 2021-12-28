using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface ICategoryRepository
    {
        Task UpdataeAsync(Category o);
        Task AddAsync(Category o);
        Task DelAsync(int id);
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> BrowseAllAsync();
    }
}
