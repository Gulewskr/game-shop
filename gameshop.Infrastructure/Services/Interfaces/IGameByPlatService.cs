using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IGameByPlatService
    {
        Task<IEnumerable<GamePlatformDTO>> GetAll();
        Task<GamePlatformDTO> Get(int id);
        Task Add(GamePlatformDTO o);
        Task Update(GamePlatformDTO o);
        Task Delete(int id);
    }
}
