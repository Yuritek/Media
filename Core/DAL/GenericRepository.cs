using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL
{
	public sealed class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
	{
		private readonly DbSet<TEntity> _dbSet;
		public GenericRepository(DbContext context)
		{
			_dbSet = context.Set<TEntity>();
		}

		public async Task<List<TEntity>> Get(
			Expression<Func<TEntity, bool>> filter = null,
			int take = 0,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
		{
			IQueryable<TEntity> query = _dbSet;
			if (filter != null)
			{
				query = query.Where(filter);
			}
			var queryOrder = orderBy?.Invoke(query) ?? query;
			return await (take > 0 ? queryOrder.Take(take).ToListAsync() : queryOrder.ToListAsync());
		}

	}
}
