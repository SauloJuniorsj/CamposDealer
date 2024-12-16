using CamposDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CamposDealer.Persistence.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<SalesEntity>
    {
        public void Configure(EntityTypeBuilder<SalesEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.SalesQtd)
                .IsRequired();

            builder
                .Property(x => x.SaleDatetime)
                .IsRequired();

            builder
                .HasOne(x => x.Client);
            
            builder
                .HasOne(x => x.Product);
        }
    }
}
