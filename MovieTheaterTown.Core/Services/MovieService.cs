using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieTheaterTown.Core.Contracts;
using MovieTheaterTown.Core.Models;
using MovieTheaterTown.Core.Profiles;
using MovieTheaterTown.Infrastructure.Data.Common;
using MovieTheaterTown.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTheaterTown.Core.Services
{
    public class MovieService(IRepository repository) : IMovieService
    {
        private readonly IMapper mapper = new MapperConfiguration(cfg 
                => cfg.AddProfile<MovieEntityProfile>())
            .CreateMapper();

        public async Task<IEnumerable<MovieModel>> GetAllAsync(bool areReadonly)
        {
            IEnumerable<Movie> entities = await 
                    (areReadonly ?
                    repository.AllReadonly<Movie>() :
                    repository.All<Movie>())
                .ToArrayAsync();

            return this.mapper.Map<MovieModel[]>(entities);
        }

        public async Task<MovieModel> GetByIdAsync(int id)
        {
            Movie entity = await repository.GetByIdAsync<Movie>(id)
                ?? throw new KeyNotFoundException();

            return this.mapper.Map<MovieModel>(entity);
        }

        public async Task<bool> ExistsByIdAsync(int id) => 
            await repository.ExistsByIdAsync<Movie>(id);

        public async Task<int> CreateAsync(MovieModel model)
        {
            Movie entity = this.mapper.Map<Movie>(model);

            await repository.AddAsync<Movie>(entity);
            await repository.SaveChangesAsync();
            
            return entity.Id;
        }

        public async Task EditAsync(int id, MovieModel model)
        {
            Movie entity = await repository.GetByIdAsync<Movie>(id)
                ?? throw new KeyNotFoundException();

            entity.Name = model.Name;
            entity.Plot = model.Plot;
            entity.Cast = [..model.Cast];
            entity.Crew = [..model.Crew];
            entity.Reviews = [..model.Reviews];
            await repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Movie? entity = await repository.GetByIdAsync<Movie>(id);
            if (entity != null)
            {
                repository.Delete<Movie>(entity);
                await repository.SaveChangesAsync();
            }
        }

        public IList<string> ValidateEntity(MovieModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model);

            if (!Validator.TryValidateObject(model, validationContext, validationResults, true))
            {
                return validationResults.Select(result => result.ErrorMessage ?? string.Empty).ToList();
            }

            return [];
        }
    }
}
