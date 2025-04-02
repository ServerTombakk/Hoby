using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;
using test.Data.Abstracts;

namespace test.Data.Concretes
{
	public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
							  where TEntity : class, IEntity, new()
							  where TContext : DbContext
	{
		protected DbContext Context;
		protected DbSet<TEntity> _entity => Context.Set<TEntity>();
		public GenericRepository(TContext context)
		{
			Context = context ?? throw new ArgumentNullException(nameof(context));
		}
		public TEntity Add(TEntity entity)
		{
			_entity.Entry(entity).State = EntityState.Added;
			Context.SaveChanges();
			return entity;
		}

		public async Task<TEntity> AddAsync(TEntity entity)
		{
			_entity.Add(entity);
			await Context.SaveChangesAsync();
			return entity;
		}

		public TEntity Delete(TEntity entity)
		{
			_entity.Remove(entity);
			Context.SaveChanges();
			return entity;

		}
		public async Task<TEntity> DeleteAsync(TEntity entity)
		{
			_entity.Remove(entity);
			await Context.SaveChangesAsync();
			return entity;
		}

		public TEntity Get(Expression<Func<TEntity, bool>> method, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool noTracking = true)
		{
			var query = Query();
			if (include != null) query = include(query);
			if (noTracking) query = query.AsNoTracking();
			return query.FirstOrDefault(method);
		}

		public IEnumerable<TEntity> GetAll(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, bool noTracking = true)
		{
			var query = Query();
			if (noTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (orderby != null) query = orderby(query);

			return query.ToList();
		}
		public async Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null, bool noTracking = true)
		{
			var query = Query();
			if (noTracking) query = query.AsNoTracking();
			if (include != null) query = include(query);
			if (orderby != null) query = orderby(query);

			return await query.ToListAsync();
		}


		public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> method, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
		{
			var query = Query();
			if (include != null) query = include(query);
			return await query.FirstOrDefaultAsync(method);

		}

		public IQueryable<TEntity> Query() => _entity;


		public TEntity Update(TEntity entity)
		{
			_entity.Update(entity);
			Context.SaveChanges();
			return entity;
		}
		public async Task<TEntity> UpdateAsync(TEntity entity)
		{
			_entity.Update(entity);
			await Context.SaveChangesAsync();
			return entity;
		}
	}

}
