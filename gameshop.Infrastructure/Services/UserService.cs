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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }
        public async Task Add(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException("coach must have value");
            await userRepository.AddAsync(new User()
            {
                Login = user.Login,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate
            });
            return;
        }

        public async Task Delete(int id)
        {
            await userRepository.DelAsync(id);
            return;
        }

        public async Task<UserDTO> Get(int id)
        {
            var z = await userRepository.GetAsync(id);
            if (z == null) return null;
            return new UserDTO()
            {
                Id = z.Id,
                Login = z.Login,
                Forename = z.Forename,
                Surname = z.Surname,
                BornDate = z.BornDate
            };
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var z = await userRepository.BrowseAllAsync();
            return z.Select(user => new UserDTO()
            {
                Id = user.Id,
                Login = user.Login,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate
            });
        }

        public async Task Update(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException("developer must have value");
            await userRepository.UpdataeAsync(new User()
            {
                Id = user.Id,
                Login = user.Login,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate
            });
            return;
        }
    }
}
