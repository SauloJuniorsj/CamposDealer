using CamposDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CamposDealer.Persistence.Context
{
    public class CamposDealerContext : DbContext
    {
        public CamposDealerContext(DbContextOptions<CamposDealerContext> options) : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SalesEntity> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
