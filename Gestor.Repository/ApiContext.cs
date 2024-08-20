using Gestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Repository
{
    public class ApiContext(DbContextOptions<ApiContext> opts) : DbContext(opts)
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientAddress> ClientAddresses { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
