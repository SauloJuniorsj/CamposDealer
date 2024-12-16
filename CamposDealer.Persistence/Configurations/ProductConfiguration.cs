using CamposDealer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CamposDealer.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.ProductValue)
                .IsRequired();
        }
    }
}