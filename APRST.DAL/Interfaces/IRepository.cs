using System.Linq;

namespace APRST.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        int GetCount();
        T GetEntityById(int id);
        void DeleteById(int id);
        IQueryable<T> GetEntities();
        IQueryable<T> GetEntitiesNoTracking();
    }
}
