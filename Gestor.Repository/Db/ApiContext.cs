using Gestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gestor.Repository.Db
{
    public class ApiContext(DbContextOptions<ApiContext> opts) : DbContext(opts)
    {
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientAddress> ClientAddresses { get; set; }

        public DbSet<Establishment> Establishments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductCrossExtras> ProductCrossExtras { get; set; }

        public DbSet<ProductExtra> ProductExtras { get; set; }

        public DbSet<ProductExtraItem> ProductExtraItems { get; set; }
    }
}
