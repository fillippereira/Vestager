using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vestager.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void AddRange(IEnumerable<TEntity> objects);
        bool Any(Func<TEntity, bool> predicate);
        bool Any();
        TEntity First();
        TEntity First(Func<TEntity, bool> predicate);
        TEntity FirstOrDefault();
        Task<TEntity> FirstOrDefaultAsync();
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        List<TEntity> GetAllAsNoTracking();
        void Remove(TEntity obj);
        void RemoveRange(IEnumerable<TEntity> objects);
        void Update(TEntity obj);
        void SetValues(TEntity newObj, TEntity obj);
        List<TEntity> Select(Func<TEntity, bool> predicate);
        void Save();
        List<TEntity> OrderByDescending(Func<TEntity, bool> predicate);
    }
}
