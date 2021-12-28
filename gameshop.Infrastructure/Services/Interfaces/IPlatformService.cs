using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IPlatformService
    {
        Task<IEnumerable<PlatformDTO>> GetAll();
        Task<PlatformDTO> Get(int id);
        Task Add(PlatformDTO o);
        Task Update(PlatformDTO o);
        Task Delete(int id);
    }
}
