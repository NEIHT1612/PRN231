using Microsoft.EntityFrameworkCore;
using ProgressTest6.Models;
using System.Linq.Expressions;

namespace ProgressTest6.Repositories.impl
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }
        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges
                ? RepositoryContext.Set<T>().AsNoTracking()
                : RepositoryContext.Set<T>();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> predicate, bool trackChanges)
        {
            return !trackChanges
                ? RepositoryContext.Set<T>().Where(predicate).AsNoTracking()
                : RepositoryContext.Set<T>().Where(predicate);
        }

        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
    }
}
