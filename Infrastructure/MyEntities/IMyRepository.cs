using System.Linq.Expressions;

namespace EFCoreBasicDemo.Infrastructure.MyEntities
{
	public interface IMyRepository<T> where T : class
	{
		Task CreateAsync(T t);
		Task DeleteAsync(T t);
		Task UpdateAsync(T t);
		IEnumerable<T> GetAll();
		Task<IEnumerable<T>> GetAllAsync();
		IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
		Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
	}
}
