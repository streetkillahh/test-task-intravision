using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DAL.Configurations;

public class CoinConfiguration : IEntityTypeConfiguration<Coin>
{
    public void Configure(EntityTypeBuilder<Coin> builder)
    {
        builder.ToTable("Coins");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Denomination)
            .IsRequired();

        builder.Property(c => c.Quantity)
            .IsRequired();
    }
}
