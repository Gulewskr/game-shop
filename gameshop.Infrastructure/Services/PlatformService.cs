using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository platformRepository;
        public PlatformService(IPlatformRepository repository)
        {
            platformRepository = repository;
        }
        public Task Add(PlatformDTO platform)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PlatformDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlatformDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(PlatformDTO platform)
        {
            throw new NotImplementedException();
        }
    }
}
