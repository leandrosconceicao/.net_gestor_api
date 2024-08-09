using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opts)
            : base(opts)
        {

        }

        public DbSet<Establishment> Establishments { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts {get; set;}

        public DbSet<Client> Clients {get; set;}

        public DbSet<ClientAddress> ClientAddresses {get; set;}


    }
}
