using Microsoft.EntityFrameworkCore;
using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.Infrastructure.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Navigation(m => m.Cast).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Crew).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Reviews).AutoInclude();
            base.OnModelCreating(modelBuilder);
        }
    }
}
