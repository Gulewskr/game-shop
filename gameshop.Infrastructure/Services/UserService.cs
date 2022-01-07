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
        private readonly IUsersRepository userRepository;
        public UserService(IUsersRepository repository)
        {
            userRepository = repository;
        }
        public async Task Add(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException("coach must have value");
            await userRepository.AddAsync(new User()
            {
                Id = user.Id,
                UserId = user.UserId,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate,
                Email = user.Email,
                Phonenumber = user.Phonenumber
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
                Forename = z.Forename,
                Surname = z.Surname,
                BornDate = z.BornDate,
                Email = z.Email,
                Phonenumber = z.Phonenumber
            };
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            var z = await userRepository.BrowseAllAsync();
            return z.Select(user => new UserDTO()
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate,
                Email = user.Email,
                Phonenumber = user.Phonenumber
            });
        }

        public async Task Update(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException("developer must have value");
            await userRepository.UpdataeAsync(new User()
            {
                Id = user.Id,
                Forename = user.Forename,
                Surname = user.Surname,
                BornDate = user.BornDate,
                Email = user.Email,
                Phonenumber = user.Phonenumber
            });
            return;
        }
    }
}
