using Store.hoso.Core.Entites;
using Store.hoso.Core.Repositories.Interfaces;
using Store.hoso.Repository.Data.DbContexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly StoreDbContext _context;
		private Hashtable _hashtable;
		
		public UnitOfWork(StoreDbContext context) 
		{
			_context = context;	
			_hashtable = new Hashtable();
		}
		public async Task<int> CompleteAsync()
		{
			return await _context.SaveChangesAsync();
		}

		public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
		{
			var type = typeof(TEntity).Name;

			var repository = new GenericRepository<TEntity, TKey>(_context);
			if (!_hashtable.ContainsKey(type)) 
			{
				_hashtable.Add(type, repository);

			}
			return _hashtable[type] as IGenericRepository<TEntity, TKey>;
		}
	}
}
