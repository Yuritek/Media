using System;
using Microsoft.EntityFrameworkCore;

namespace Core.DAL
{
	public sealed class UnitOfWork<TEntity> : IDisposable where TEntity : class, new()
	{
		private readonly DbContext _context;
		private GenericRepository<TEntity> _contextRepository;
		public GenericRepository<TEntity> Repository => _contextRepository ?? new GenericRepository<TEntity>(_context);

		public UnitOfWork(DbContext context)
		{
			_context = context;
		}
		private bool _disposed;
		private void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
