using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Weapsy.Blog.Domain.Persistence.EF
{
	public interface IDbContext : IDisposable
	{
		IDbSet<T> Set<T>() where T : class, IEntity;
		DbEntityEntry<T> Entry<T>(T entity) where T : class, IEntity;
		int SaveChanges();
		Database Database { get; }
	}
}
