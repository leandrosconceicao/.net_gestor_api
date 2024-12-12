using Gestor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Gestor.Repository.Db
{
    public class ApiContext(DbContextOptions<ApiContext> opts) : DbContext(opts)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => new {u.Email, u.EstablishmentId })
                .IsUnique();

            modelBuilder.Entity<Establishment>()
                .HasIndex(est => new { est.OwnerId, est.Description })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(prod => new { prod.EstablishmentId, prod.Name })
                .IsUnique();

            modelBuilder.Entity<ProductCategory>()
                .HasIndex(cat => new { cat.EstablishmentId, cat.Description })
                .IsUnique();
            
            modelBuilder.Entity<ProductExtra>()
                .HasIndex(prodEx => new { prodEx.EstablishmentId, prodEx.Name })
                .IsUnique();
        }
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
