using System.Linq;

namespace Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }
        void Remove(T entity);
        void Add(T entity);
    }
}
