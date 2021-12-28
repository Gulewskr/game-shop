using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository passwordRepository;
        public PasswordService(IPasswordRepository repository)
        {
            passwordRepository = repository;
        }
        public Task Add(PasswordDTO password)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PasswordDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PasswordDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(PasswordDTO password)
        {
            throw new NotImplementedException();
        }
    }
}
