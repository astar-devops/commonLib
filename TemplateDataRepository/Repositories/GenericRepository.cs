using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TemplateDataRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TemplateDataRepository.Repositories
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
	{
		protected readonly ApplicationDbContext Context;

		public GenericRepository(ApplicationDbContext context)
		{
			Context = context;
			Context.Database.SetCommandTimeout(180);
		}

		public IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = Context.Set<TEntity>();

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public TEntity GetByID(object id)
		{
			return Context.Set<TEntity>().Find(id);
		}

		public void Add(TEntity entity)
		{
			Context.Set<TEntity>().Add(entity);
		}

		public void Update(TEntity entityToUpdate)
		{
			Context.Set<TEntity>().Attach(entityToUpdate);
			Context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public void Delete(object id)
		{
			TEntity entityToDelete = Context.Set<TEntity>().Find(id);
			Delete(entityToDelete);
		}

		public void Delete(TEntity entityToDelete)
		{
			if (Context.Entry(entityToDelete).State == EntityState.Detached)
			{
				Context.Set<TEntity>().Attach(entityToDelete);
			}
			Context.Set<TEntity>().Remove(entityToDelete);
		}
	}
}
