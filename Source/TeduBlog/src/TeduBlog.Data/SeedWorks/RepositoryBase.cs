using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeduBlog.Core.SeedWorks;

namespace TeduBlog.Data.SeedWorks
{
    public class RepositoryBase<T, Key> : IRepository<T, Key> where T : class
    {
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(AppDBContext context)
        {
            _dbSet = context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.AddAsync(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Key id)
        {
            return await _dbSet.FindAsync(id);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task Remove(Key id)
        {
            T en = await GetByIdAsync(id);
            Remove(en);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _dbSet.UpdateRange(entities);
        }
    }
}
