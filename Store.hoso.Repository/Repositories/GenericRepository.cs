using Microsoft.EntityFrameworkCore;
using Store.hoso.Core.Entites;
using Store.hoso.Core.Repositories.Interfaces;
using Store.hoso.Repository.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Repository.Repositories
{
	public class GenericRepository<TEntity, Tkey> : IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
	{
		private readonly StoreDbContext _context;
		public GenericRepository(StoreDbContext context) 
		{
			_context = context;	
		}
		public async Task<IEnumerable<TEntity>> GetAllAsync()
		{
			if (typeof(TEntity) == typeof(Product)) 
			{
				return (IEnumerable<TEntity>) await _context.Products.Include(p => p.Brand).Include(p => p.Type).ToListAsync() ;
			}


			return await _context.Set<TEntity>().ToListAsync();
		}

		public async Task<TEntity> GetByIdAsync(Tkey id)
		{
			if (typeof(TEntity) == typeof(Product)) 
			{
				return  await _context.Products.Include(p => p.Brand).Include(p => p.Type).FirstOrDefaultAsync(p=>p.Id ==id as int?) as TEntity;
			}
				return await _context.Set<TEntity>().FindAsync(id);
		}
		public async Task AddAsync(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
		}
		public void Update(TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
		}
		public void Delete(TEntity entity)
		{
			_context.Set<TEntity>().Remove(entity);
		}





	}
	
	
}
