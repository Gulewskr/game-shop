using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository repository)
        {
            categoryRepository = repository;
        }
        public async Task Add(CategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException("coach must have value");
            await categoryRepository.AddAsync(new Category()
            {
                Name = category.Name
            });
            return;
        }

        public async Task Delete(int id)
        {
            await categoryRepository.DelAsync(id);
            return;
        }

        public async Task<CategoryDTO> Get(int id)
        {
            var z = await categoryRepository.GetAsync(id);
            if (z == null) return null;
            return new CategoryDTO()
            {
                Id = z.Id,
                Name = z.Name
            };
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var z = await categoryRepository.BrowseAllAsync();
            return z.Select(z => new CategoryDTO()
            {
                Id = z.Id,
                Name = z.Name
            });
        }

        public async Task Update(CategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException("developer must have value");
            await categoryRepository.UpdataeAsync(new Category()
            {
                Id = category.Id,
                Name = category.Name
            });
            return;
        }
    }
}
