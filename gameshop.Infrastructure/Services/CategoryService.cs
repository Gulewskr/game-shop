using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
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
        public Task Add(CategoryDTO category)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO category)
        {
            throw new NotImplementedException();
        }
    }
}
