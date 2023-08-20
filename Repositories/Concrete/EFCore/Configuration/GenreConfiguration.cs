using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Models.Concrete.Entities;


namespace Repositories.Concrete.EFCore.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {

            builder.HasData(new Genre
            {
                Id = 1,
                Name = "Sci-Fi",
            });

            builder.HasData(new Genre
            {
                Id = 2,
                Name = "Horror",
            });

            builder.HasData(new Genre
            {
                Id = 3,
                Name = "Action",
            });

            builder.HasData(new Genre
            {
                Id = 4,
                Name = "Adventure",
            });

            builder.HasData(new Genre
            {
                Id = 5,
                Name = "Drama",
            });
        }

    }
}
