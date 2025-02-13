﻿using Store.hoso.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.hoso.Core.Repositories.Interfaces
{
	public interface IGenericRepository<TEntity,TKey>where TEntity : BaseEntity<TKey>
	{
		Task<IEnumerable<TEntity>> GetAllAsync();
		Task<TEntity> GetByIdAsync(TKey id);
		Task AddAsync(TEntity entity);
		void Update(TEntity entity);
		void Delete(TEntity entity);

	}
}
