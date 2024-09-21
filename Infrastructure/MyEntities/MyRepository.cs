using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EFCoreDemo1.Infrastructure.MyEntities
{
	public abstract class MyRepository<TEntry, TDBContext> : IMyRepository<TEntry> where TEntry : class where TDBContext : DbContext
	{
		protected TDBContext Context;
		public MyRepository(TDBContext context)
		{
			Context = context;
			//Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public async Task CreateAsync(TEntry t)
		{
			Context.Set<TEntry>().Add(t);
			await Context.SaveChangesAsync();
		}

		public async Task DeleteAsync(TEntry t)
		{
			Context.Set<TEntry>().Remove(t);
			await Context.SaveChangesAsync();
		}

		public async Task UpdateAsync(TEntry t)
		{
			Context.Set<TEntry>().Update(t);
			await Context.SaveChangesAsync();
		}

		public IEnumerable<TEntry> Find(Expression<Func<TEntry, bool>> predicate)
		{
			return Context.Set<TEntry>().Where(predicate);
		}

		public async Task<List<TEntry>> FindAsync(Expression<Func<TEntry, bool>> predicate)
		{
			return await Context.Set<TEntry>().Where(predicate).ToListAsync();
		}

		public IEnumerable<TEntry> GetAll()
		{
			return Context.Set<TEntry>().ToList();
		}

		public async Task<IEnumerable<TEntry>> GetAllAsync()
		{
			return await Context.Set<TEntry>().ToListAsync();
		}
	}
}
