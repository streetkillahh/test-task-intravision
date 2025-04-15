using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.DAL.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(o => o.Id);

        builder.Property(o => o.CreatedAt)
            .HasDefaultValueSql("GETUTCDATE()");

        builder.Property(o => o.TotalPrice)
            .HasColumnType("decimal(10, 2)")
            .IsRequired();

        builder.HasMany(o => o.Items)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
