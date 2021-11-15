using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ServiceLayer.Model;

namespace ServiceLayer
{
    public class AppDbContext : DbContext
    {

      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActorType> ActorTypes { get; set; }

        public DbSet<Tags> Tags { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<Movies>()
                .HasMany(x => x.MovieDetails)
                .WithOne(x => x.Movie);

        }
    }
}
