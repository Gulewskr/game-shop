using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class UserRepository : IUsersRepository
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
                //_appDbContext.User.Add(o);
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
            return await Task.FromResult(_appDbContext.User);
           // await Task.CompletedTask;
            //return new List<User>();
        }

        public async Task DelAsync(int id)
        {
            try
            {
                User u = _appDbContext.User.FirstOrDefault(x => x.Id == id);
                //var user = await _userManager.FindByIdAsync(u.Id);
                _appDbContext.Remove(u);
                //await _userManager.DeleteAsync(user);
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
            return await Task.FromResult(_appDbContext.User.FirstOrDefault(x => x.Id == id));
            //return null;
        }

        public async Task UpdataeAsync(User o)
        {
            try
            {
                var z = _appDbContext.User.FirstOrDefault(x => x.Id == o.Id);
                //var user = await _userManager.FindByIdAsync(z.Id);
                //if (user != null)
                //{
                //    user.Email = o.Email;
                //}
                z.Email = o.Email;
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
