using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vestager.Domain.Interfaces.Repositories;
using Vestager.Infra.Data;

namespace Vestager.Infra.Repositories
{
   public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: class
    {
        private Context _context;
      

        public BaseRepository(Context context)
        {
            _context = context;   
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }
        public void AddRange(IEnumerable<TEntity> objects)
        {
            _context.Set<TEntity>().AddRange(objects);
        }
        public bool Any(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }
        public bool Any()
        {
            return _context.Set<TEntity>().Any();
        }
        public TEntity First()
        {
            return _context.Set<TEntity>().First();
        }
        public TEntity First(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().First(predicate);
        }
        public TEntity FirstOrDefault()
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }
        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }


        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return  _context.Set<TEntity>().FirstOrDefault(predicate);
        }
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }


        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public List<TEntity> GetAllAsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }
        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
        }
        public void RemoveRange(IEnumerable<TEntity> objects)
        {
            _context.Set<TEntity>().RemoveRange(objects);
        }
        public void Update(TEntity obj)
        {
            _context.Set<TEntity>().Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void SetValues(TEntity newObj, TEntity obj)
        {
            _context.Entry(newObj).CurrentValues.SetValues(obj);
        }

        public List<TEntity> Select(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }       

        public List<TEntity> OrderByDescending(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().OrderByDescending(predicate).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
