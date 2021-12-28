using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAll();
        Task<OrderDTO> Get(int id);
        Task Add(OrderDTO o);
        Task Update(OrderDTO o);
        Task Delete(int id);
    }
}
