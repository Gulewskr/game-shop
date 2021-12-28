using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> Get(int id);
        Task Add(UserDTO o);
        Task Update(UserDTO o);
        Task Delete(int id);
    }
}
