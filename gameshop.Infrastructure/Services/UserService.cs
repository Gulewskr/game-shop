using gameshop.Core.Repositories;
using gameshop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }
        public Task Add(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
