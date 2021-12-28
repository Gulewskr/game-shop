using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IPublisherRepository
    {
        Task UpdataeAsync(Publisher o);
        Task AddAsync(Publisher o);
        Task DelAsync(int id);
        Task<Publisher> GetAsync(int id);
        Task<IEnumerable<Publisher>> BrowseAllAsync();
    }
}
