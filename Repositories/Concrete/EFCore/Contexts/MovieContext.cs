using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Models.Concrete.Entities;

namespace Repositories.Concrete.EFCore.Contexts
{
    public class MovieContext : DbContext
    {
        public DbSet<AwardType> AwardTypes { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MovieRole> MovieRoles { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MovieApp;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
