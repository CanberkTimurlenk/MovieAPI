using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities;

namespace Repositories.Concrete.EFCore.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //  Shadow Property
            builder.Property<DateTime?>("LastModified").HasColumnType("date");

            builder.Property(m => m.ReleaseDate).HasColumnType("date");

            builder.ToTable(m => m.HasTrigger("TRG_Movies_LastModified_After_Update_GetDate"));


            builder.HasData(new Movie
            {
                Id = 1,
                Title = "The Thing",
                ReleaseDate = new DateTime(1982, 6, 25),
                DurationAsMinute = 119,
                IsReleased = true,                
                
            });

            builder.HasData(new Movie
            {
                Id = 2,
                Title = "Citizen Kane",
                ReleaseDate = new DateTime(1941, 9, 5),
                DurationAsMinute = 120,
                IsReleased = true,
                
            });

            builder.HasData(new Movie
            {
                Id = 3,
                Title = "Escape From New York",
                ReleaseDate = new DateTime(1981, 7, 10),
                DurationAsMinute = 99,
                IsReleased = true,
                
            });

            builder.HasData(new Movie
            {
                Id = 4,
                Title = "Seven Samurai",
                ReleaseDate = new DateTime(1954, 4, 26),
                DurationAsMinute = 207,
                IsReleased = true,
                
            });

            builder.HasData(new Movie
            {
                Id = 5,
                Title = "Dark City",
                ReleaseDate = new DateTime(1998, 10, 16),
                DurationAsMinute = 100,
                IsReleased = true,
                
            });
            
        }
    }
}
