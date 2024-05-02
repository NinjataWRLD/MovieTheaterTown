using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieTheaterTown.Infrastructure.Data.Common
{
    public class Repository(MovieContext context) : IRepository
    {
        public IQueryable<T> All<T>() where T : class
            => context.Set<T>();

        public IQueryable<T> AllReadonly<T>() where T : class
            => context.Set<T>().AsNoTracking();

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
            => await context.Set<T>().FindAsync(id);

        public async Task<bool> ExistsByIdAsync<T>(object id) where T : class
            => await context.Set<T>().FindAsync(id) != null;

        public async Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class 
            => await context.Set<T>().AddAsync(entity);

        public void Delete<T>(T entity) where T : class 
            => context.Set<T>().Remove(entity);

        public async Task SaveChangesAsync() 
            => await context.SaveChangesAsync();
    }
}
