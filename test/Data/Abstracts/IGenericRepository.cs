using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace test.Data.Abstracts
{
	public interface IGenericRepository<T> : IQuery<T> where T : IEntity
	{
		T Add(T entity);
		Task<T> AddAsync(T entity);
		T Update(T entity);
		Task<T> UpdateAsync(T entity);
		T Delete(T entity);
		Task<T> DeleteAsync(T entity);

		T Get(Expression<Func<T, bool>> method, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool noTracking = true);
		Task<T> GetAsync(Expression<Func<T, bool>> method, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

		IEnumerable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
										  Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
										  bool noTracking = true);
		Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
								  Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
								  bool noTracking = true);
	}
}
