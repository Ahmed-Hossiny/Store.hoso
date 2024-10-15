using Store.hoso.Core.Entites;
using Store.hoso.Repository.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.hoso.Repository.SeedingHelperClass
{
	public static class StoreDbContextSeeding
	{
	
		public static async Task Seeding(StoreDbContext context) 
		{
			if (context.Brands.Count() == 0) 
			{
				var J_Brands = File.ReadAllText(@"..\Store.hoso.Repository\DataSeed\brands.json");
				var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(J_Brands);
				if (Brands is not null && Brands.Count() > 0)
				{
					await context.Brands.AddRangeAsync(Brands);
					await context.SaveChangesAsync();
				}
			}

			if (context.Types.Count() == 0) 
			{
				var J_Types = File.ReadAllText(@"..\Store.hoso.Repository\DataSeed\types.json");
				var Types = JsonSerializer.Deserialize<List<ProductType>>(J_Types);
				if (Types is not null && Types.Count() > 0)
				{
					await context.Types.AddRangeAsync(Types);
					await context.SaveChangesAsync();

				}
			}

			if (context.Products.Count() == 0) 
			{
				var J_Products = File.ReadAllText(@"..\Store.hoso.Repository\DataSeed\products.json");
				var Products = JsonSerializer.Deserialize<List<Product>>(J_Products);
				if (Products is not null && Products.Count() > 0) 
				{
					await context.Products.AddRangeAsync(Products);
					await context.SaveChangesAsync();

				}
			}

		}
	}
}
