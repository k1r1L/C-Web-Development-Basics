namespace ForumMVC.App.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using Contracts;

    public abstract class GenericRepository<T> : IRepository<T>
        where T : class
    {
        protected IDbSet<T> entityTable;

        protected GenericRepository(IForumContext dbContext)
        {
            this.entityTable = dbContext.Set<T>();
        }

        public void Insert(T entity)
        {
            this.entityTable.Add(entity);
        }

        public void Delete(T entity)
        {
            this.entityTable.Remove(entity);
        }

        public T Find(object id)
        {
            return this.entityTable.Find(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return this.entityTable.FirstOrDefault(predicate);
        }

        public IQueryable<T> All()
        {
            return this.entityTable;
        }

        public IQueryable<T> All(Expression<Func<T, bool>> expression)
        {
            return this.entityTable.Where(expression);
        }
    }
}
