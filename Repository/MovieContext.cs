using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MovieContext: DbContext
    {
        public MovieContext()
        {
                   }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}