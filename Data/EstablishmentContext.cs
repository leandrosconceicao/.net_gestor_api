using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class EstablishmentContext : DbContext
    {
        public EstablishmentContext(DbContextOptions<EstablishmentContext> opts)
            : base(opts)
        {

        }

        public DbSet<Establishment> Establishments { get; set; }
    }
}
