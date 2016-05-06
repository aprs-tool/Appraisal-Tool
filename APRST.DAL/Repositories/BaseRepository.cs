using APRST.DAL.EF;
using APRST.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APRST.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
            DbSet.Remove(entity);
        }

        public virtual void Update(T entity)
        {
            var entry = _context.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public IQueryable<T> GetEntities()
        {
            //return DbSet.AsQueryable();
            return DbSet.AsNoTracking();
        }

        public T GetEntityById(int id)
        {
            return DbSet.Find(id);
        }

        public void DeleteById(int id)
        {
            var a = DbSet.Find(id);
            DbSet.Remove(a);
        }
    }
}
