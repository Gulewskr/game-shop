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
    public class PasswordService : IPasswordService
    {
        private readonly IPasswordRepository passwordRepository;
        public PasswordService(IPasswordRepository repository)
        {
            passwordRepository = repository;
        }
        public async Task Add(PasswordDTO password)
        {
            if (password == null) throw new ArgumentNullException("coach must have value");
            await passwordRepository.AddAsync(new Password()
            {
                UserID = password.UserID,
                Salt = password.Salt,
                HashedPassword = password.HashedPassword
            });
            return;
        }

        public async Task Delete(int id)
        {
            await passwordRepository.DelAsync(id);
            return;
        }

        public async Task<PasswordDTO> Get(int id)
        {
            var z = await passwordRepository.GetAsync(id);
            if (z == null) return null;
            return new PasswordDTO()
            {
                Id = z.Id,
                UserID = z.UserID,
                Salt = z.Salt,
                HashedPassword = z.HashedPassword
            };
        }

        public async Task<IEnumerable<PasswordDTO>> GetAll()
        {
            var z = await passwordRepository.BrowseAllAsync();
            return z.Select(password => new PasswordDTO()
            {
                Id = password.Id,
                UserID = password.UserID,
                Salt = password.Salt,
                HashedPassword = password.HashedPassword
            });
        }

        public async Task Update(PasswordDTO password)
        {
            if (password == null) throw new ArgumentNullException("developer must have value");
            await passwordRepository.UpdataeAsync(new Password()
            {
                Id = password.Id,
                UserID = password.UserID,
                Salt = password.Salt,
                HashedPassword = password.HashedPassword
            });
            return;
        }
    }
}
