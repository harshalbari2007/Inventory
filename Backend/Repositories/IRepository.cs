using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        T GetById(object id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task AddRange(List<T> entities);
    }
}
