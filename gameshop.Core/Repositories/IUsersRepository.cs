using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IUsersRepository
    {
        Task UpdataeAsync(User o);
        Task AddAsync(User o);
        Task DelAsync(int id);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> BrowseAllAsync();
    }
}