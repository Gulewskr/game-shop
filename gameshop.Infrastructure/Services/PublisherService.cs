using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
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
        public Task Add(PublisherDTO publisher)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PublisherDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PublisherDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(PublisherDTO publisher)
        {
            throw new NotImplementedException();
        }
    }
}
