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
        Task<T> GetEntityByIdAsync(int id);
        void DeleteById(int id);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetEntities();
        IQueryable<T> GetEntitiesNoTracking();
    }
}
