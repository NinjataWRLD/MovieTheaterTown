using Microsoft.EntityFrameworkCore;
using MovieTheatreTown.Infrastructure.Data.Models;

namespace MovieTheatreTown.Infrastructure.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
