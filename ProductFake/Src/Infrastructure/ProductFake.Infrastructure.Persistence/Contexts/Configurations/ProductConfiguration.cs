﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductFake.Domain.Products.Entities;

namespace ProductFake.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.BarCode).HasMaxLength(50);
        }
    }
}
