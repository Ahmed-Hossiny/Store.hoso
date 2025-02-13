﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.hoso.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Repository.Data.Configurations
{
	public class ProductConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
			builder.Property(p => p.Description).IsRequired();
			builder.Property(p => p.Price).HasColumnType("decimal(18,2)").IsRequired();
			builder.Property(p => p.PictureUrl).IsRequired();
			builder.HasOne(p => p.Brand)
				   .WithMany()
				   .HasForeignKey(p => p.BrandId)
				   .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
			builder.HasOne(p => p.Type)
				   .WithMany()
				   .HasForeignKey(p => p.TypeId)
				   .OnDelete(deleteBehavior: DeleteBehavior.SetNull);
			builder.Property(p => p.BrandId).IsRequired(false);
			builder.Property(p => p.TypeId).IsRequired(false);
		}
	}
}
