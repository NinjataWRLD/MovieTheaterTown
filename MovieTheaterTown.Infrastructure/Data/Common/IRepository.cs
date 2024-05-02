using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MovieTheatreTown.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllReadonly<T>() where T : class;
        Task<T?> GetByIdAsync<T>(object id) where T : class;
        Task<bool> ExistsByIdAsync<T>(object id) where T : class;
        Task<EntityEntry<T>> AddAsync<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
