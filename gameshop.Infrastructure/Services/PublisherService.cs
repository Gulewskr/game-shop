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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository publisherRepository;
        public PublisherService(IPublisherRepository repository)
        {
            publisherRepository = repository;
        }
        public async Task Add(PublisherDTO publisher)
        {
            if (publisher == null) throw new ArgumentNullException("coach must have value");
            await publisherRepository.AddAsync(new Publisher()
            {
                Name = publisher.Name,
                EMail = publisher.EMail,
                Country = publisher.Country,
                City = publisher.City,
                Address = publisher.Address,
                ImageURL = publisher.ImageURL
            });
            return;
        }

        public async Task Delete(int id)
        {
            await publisherRepository.DelAsync(id);
            return;
        }

        public async Task<PublisherDTO> Get(int id)
        {
            var z = await publisherRepository.GetAsync(id);
            if (z == null) return null;
            return new PublisherDTO()
            {
                Id = z.Id,
                Name = z.Name,
                EMail = z.EMail,
                Country = z.Country,
                City = z.City,
                Address = z.Address,
                ImageURL = z.ImageURL
            };
        }

        public async Task<IEnumerable<PublisherDTO>> GetAll()
        {
            var z = await publisherRepository.BrowseAllAsync();
            return z.Select(publisher => new PublisherDTO()
            {
                Id = publisher.Id,
                Name = publisher.Name,
                EMail = publisher.EMail,
                Country = publisher.Country,
                City = publisher.City,
                Address = publisher.Address,
                ImageURL = publisher.ImageURL
            });
        }

        public async Task Update(PublisherDTO publisher)
        {
            if (publisher == null) throw new ArgumentNullException("developer must have value");
            await publisherRepository.UpdataeAsync(new Publisher()
            {
                Id = publisher.Id,
                Name = publisher.Name,
                EMail = publisher.EMail,
                Country = publisher.Country,
                City = publisher.City,
                Address = publisher.Address,
                ImageURL = publisher.ImageURL
            });
            return;
        }
    }
}
