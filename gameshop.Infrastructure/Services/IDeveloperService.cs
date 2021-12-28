using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IDeveloperService
    {
        Task<IEnumerable<DeveloperDTO>> GetAll();
        Task<DeveloperDTO> Get(int id);
        Task Add(DeveloperDTO o);
        Task Update(DeveloperDTO o);
        Task Delete(int id);
    }
}
