using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private AppDbContext _appDbContext;
        public PasswordRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Password o)
        {
            try
            {
                _appDbContext.Passwords.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Password>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Passwords);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Passwords.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Password> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Passwords.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Password o)
        {
            try
            {
                var z = _appDbContext.Passwords.FirstOrDefault(x => x.Id == o.Id);
                z.UserID = o.UserID;
                z.Salt = o.Salt;
                z.HashedPassword = o.HashedPassword;

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
