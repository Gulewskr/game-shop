using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(User o)
        {
            try
            {
                _appDbContext.Users.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<User>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Users);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Users.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<User> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Users.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(User o)
        {
            try
            {
                var z = _appDbContext.Users.FirstOrDefault(x => x.Id == o.Id);
                z.Login = o.Login;
                z.Forename = o.Forename;
                z.Surname = o.Surname;
                z.BornDate = o.BornDate;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }
    }
}
