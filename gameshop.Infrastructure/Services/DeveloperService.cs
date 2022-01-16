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
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository developerRepository;
        public DeveloperService(IDeveloperRepository repository)
        {
            developerRepository = repository;
        }
        public async Task Add(DeveloperDTO developer)
        {
            if (developer == null) throw new ArgumentNullException("coach must have value");
            await developerRepository.AddAsync(new Developer()
            {
                Name = developer.Name,
                Address = developer.Address,
                City = developer.City,
                Country = developer.Country,
                EMail = developer.EMail,
                ImageURL = developer.ImageURL
            });
            return;
        }

        public async Task Delete(int id)
        {
            await developerRepository.DelAsync(id);
            return;
        }

        public async Task<DeveloperDTO> Get(int id)
        {
            var z = await developerRepository.GetAsync(id);
            if (z == null) return null;
            return new DeveloperDTO()
            {
                Id = z.Id,
                Name = z.Name,
                Address = z.Address,
                City = z.City,
                Country = z.Country,
                EMail = z.EMail,
                ImageURL = z.ImageURL
            };
        }

        public async Task<IEnumerable<DeveloperDTO>> GetAll()
        {
            var z = await developerRepository.BrowseAllAsync();
            return z.Select(x => new DeveloperDTO()
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                City = x.City,
                Country = x.Country,
                EMail = x.EMail,
                ImageURL = x.ImageURL
            });
        }

        public async Task Update(DeveloperDTO developer)
        {
            if (developer == null) throw new ArgumentNullException("developer must have value");
            await developerRepository.UpdataeAsync(new Developer()
            {
                Id = developer.Id,
                Name = developer.Name,
                Address = developer.Address,
                City = developer.City,
                Country = developer.Country,
                EMail = developer.EMail,
                ImageURL = developer.ImageURL
            });
            return;
        }
    }
}
