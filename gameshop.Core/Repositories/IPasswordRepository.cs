﻿using gameshop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace gameshop.Core.Repositories
{
    public interface IPasswordRepository
    {
        Task UpdataeAsync(Password o);
        Task AddAsync(Password o);
        Task DelAsync(int id);
        Task<Password> GetAsync(int id);
        Task<IEnumerable<Password>> BrowseAllAsync();
    }
}
