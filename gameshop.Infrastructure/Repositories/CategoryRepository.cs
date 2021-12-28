using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _appDbContext;
        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Category o)
        {
            try
            {
                _appDbContext.Categories.Add(o);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Category>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Categories);
        }

        public async Task DelAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Categories.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception e)
            {
                await Task.FromException(e);
            }
        }

        public async Task<Category> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Categories.FirstOrDefault(x => x.Id == id));
        }

        public async Task UpdataeAsync(Category o)
        {
            try
            {
                var z = _appDbContext.Categories.FirstOrDefault(x => x.Id == o.Id);
                z.Name = o.Name;

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
