
using Microsoft.EntityFrameworkCore;
using Store.hoso.Core.Maaping.Products;
using Store.hoso.Core.Repositories.Interfaces;
using Store.hoso.Core.Services.Interfaces;
using Store.hoso.Repository.Data.DbContexts;
using Store.hoso.Repository.Repositories;
using Store.hoso.Repository.SeedingHelperClass;
using Store.hoso.Service.Services;

namespace Store.hoso.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<StoreDbContext>
				(
				    option =>
				               option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
				);
			builder.Services.AddScoped<IServices, Services>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
			builder.Services.AddAutoMapper(m => m.AddProfile(new ProductProfile()));


			var app = builder.Build();

			using var Scope = app.Services.CreateScope();
			var services = Scope.ServiceProvider;
			var Context = services.GetRequiredService<StoreDbContext>();
			try
			{
				await Context.Database.MigrateAsync();
				await StoreDbContextSeeding.Seeding(Context);
			}
			catch (Exception ex) 
			{
                Console.WriteLine(ex.Message);
            }



			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
