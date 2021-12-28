using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> Get(int id);
        Task Add(CategoryDTO o);
        Task Update(CategoryDTO o);
        Task Delete(int id);
    }
}
