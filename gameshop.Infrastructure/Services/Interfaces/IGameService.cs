using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> GetAll();
        Task<GameDTO> Get(int id);
        Task Add(GameDTO o);
        Task Update(GameDTO o);
        Task Delete(int id);
    }
}
