using gameshop.Core.Domain;
using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task Add(PlatformDTO platform)
        {
            if (platform == null) throw new ArgumentNullException("coach must have value");
            await platformRepository.AddAsync(new Platform()
            {
                Name = platform.Name,
                ImageURL = platform.ImageURL
            });
            return;
        }

        public async Task Delete(int id)
        {
            await platformRepository.DelAsync(id);
            return;
        }

        public async Task<PlatformDTO> Get(int id)
        {
            var z = await platformRepository.GetAsync(id);
            if (z == null) return null;
            return new PlatformDTO()
            {
                Id = z.Id,
                Name = z.Name,
                ImageURL = z.ImageURL
            };
        }

        public async Task<IEnumerable<PlatformDTO>> GetAll()
        {
            var z = await platformRepository.BrowseAllAsync();
            return z.Select(platform => new PlatformDTO()
            {
                Id = platform.Id,
                Name = platform.Name,
                ImageURL = platform.ImageURL
            });
        }

        public async Task Update(PlatformDTO platform)
        {
            if (platform == null) throw new ArgumentNullException("developer must have value");
            await platformRepository.UpdataeAsync(new Platform()
            {
                Id = platform.Id,
                Name = platform.Name,
                ImageURL = platform.ImageURL
            });
            return;
        }
    }
}
