using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RecipeJourneyRa.Data;
using RecipeJourneyRa.Interfaces;
using RecipeJourneyRa.Models;

namespace RecipeJourneyRa.Repository
{
    public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await SaveAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}