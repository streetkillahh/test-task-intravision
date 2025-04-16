﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Infrastructure.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(oi => oi.Id);

        builder.Property(oi => oi.ProductId)
               .IsRequired();

        builder.Property(oi => oi.ProductName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(oi => oi.BrandName)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(oi => oi.Quantity)
               .IsRequired();

        builder.Property(oi => oi.PricePerItem)
               .HasColumnType("decimal(10, 2)")
               .IsRequired();
    }
}