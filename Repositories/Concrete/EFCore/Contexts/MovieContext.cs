using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Models.Concrete.Entities;
using Models.Concrete.Entities.Junctions;
using Models.Concrete.Domains.Junctions;

using Models.Concrete.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Repositories.Concrete.EFCore.Contexts
{
    public class MovieContext : IdentityDbContext<User>
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }              
        public DbSet<AwardType> AwardTypes { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PersonGenre> PersonGenres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<MovieLocation> MovieLocations { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }        
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Person> Persons { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
