using MovieTheaterTown.Core.Models;

namespace MovieTheaterTown.Core.Contracts
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieModel>> GetAllAsync(bool areReadonly = true);
        Task<MovieModel> GetByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
        Task<int> CreateAsync(MovieModel model);
        Task EditAsync(int id, MovieModel model);
        Task DeleteAsync(int id);
        IList<string> ValidateEntity(MovieModel model);
    }
}
