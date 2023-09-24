using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities.Junctions;

namespace Repositories.Concrete.EFCore.Configurations.Junctions
{
    public class MovieGenreConfiguration : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(mg => new { mg.MovieId, mg.GenreId });

            builder.HasOne(mg => mg.Movie)
                   .WithMany(m => m.Genres)
                   .HasForeignKey(mg => mg.MovieId);

            builder.HasOne(mg => mg.Genre)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(mg => mg.GenreId);

        }
    }
}
