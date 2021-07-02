using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DatabaseContext DbContext = new DatabaseContext("sdsd");
        protected async Task Save() => await DbContext.SaveChangesAsync();

        public Repository(DatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual async Task Add(T entity)
        {
            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Added;
            await Save();
        }

        public virtual async Task AddRange(List<T> entities)
        {
            foreach (var item in entities)
            {
                DbContext.Entry(item).State = System.Data.Entity.EntityState.Added;
            }
            await Save();
        }


        public virtual async Task Delete(T entity)
        {
            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            await Save();
        }

        public virtual async Task Update(T entity)
        {
            DbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;            
            await Save();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public T GetById(object id)
        {
            return DbContext.Set<T>().Find(id);
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }
    }
}
