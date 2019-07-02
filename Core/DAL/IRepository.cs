using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Core.DAL
{
	public interface IRepository<TEntity> where TEntity : class, new()
	{
		Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter, int take,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy);
	}
}
