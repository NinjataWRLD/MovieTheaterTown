﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieTheaterTown.Infrastructure.Data.Models;

namespace MovieTheaterTown.Infrastructure.Data
{
    public class MovieContext(DbContextOptions<MovieContext> options) : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserMovie> UsersMovie { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Navigation(m => m.Cast).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Crew).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Reviews).AutoInclude();
            modelBuilder.Entity<Movie>().Navigation(m => m.Saved).AutoInclude();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
