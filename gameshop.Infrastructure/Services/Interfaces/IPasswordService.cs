using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IPasswordService
    {
        Task<IEnumerable<PasswordDTO>> GetAll();
        Task<PasswordDTO> Get(int id);
        Task Add(PasswordDTO o);
        Task Update(PasswordDTO o);
        Task Delete(int id);
    }
}
