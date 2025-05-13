using System.Linq.Expressions;
using RecipeJourneyRa.Models;

namespace RecipeJourneyRa.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task SaveAsync();
    }
}