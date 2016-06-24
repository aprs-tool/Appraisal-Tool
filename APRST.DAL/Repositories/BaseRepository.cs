using APRST.DAL.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace APRST.DAL.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected DbSet<T> DbSet => _context.Set<T>();

        protected BaseRepository(DbContext context)
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
            return DbSet.AsQueryable();
        }
        public IQueryable<T> GetEntitiesNoTracking()
        {
            return DbSet.AsNoTracking();
        }

        public T GetEntityById(int id)
        {
            return DbSet.Find(id);
        }

        public void DeleteById(int id)
        {
            var entityToDelete = DbSet.Find(id);
            if (entityToDelete!=null) DbSet.Remove(entityToDelete);
        }

        public async Task<T> GetEntityByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entityToDelete = await DbSet.FindAsync(id);
            if (entityToDelete != null) DbSet.Remove(entityToDelete);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public int GetCount()
        {
            return DbSet.AsNoTracking().Count();
        }
    }
}
