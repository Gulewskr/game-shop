using gameshop.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace gameshop.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameByPlatformSpec> GamesByPlatform { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Platform> Play { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
