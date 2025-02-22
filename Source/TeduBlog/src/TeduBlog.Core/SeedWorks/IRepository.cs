using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TeduBlog.Core.SeedWorks
{
    public interface IRepository<T, K> where T : class
    {
        Task<T> GetByIdAsync(K id);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(List<T> entities);

        void Remove(T entity);
        Task Remove(K id);
        void RemoveRange(IEnumerable<T> entities);
    }
}
