using Store.hoso.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Core.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int>CompleteAsync();
		IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
	}
}
