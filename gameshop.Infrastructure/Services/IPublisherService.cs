using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherDTO>> GetAll();
        Task<PublisherDTO> Get(int id);
        Task Add(PublisherDTO o);
        Task Update(PublisherDTO o);
        Task Delete(int id);
    }
}
