using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities.Junctions;

namespace Repositories.Concrete.EFCore.Configurations.Junctions
{
    public class MovieLocationConfiguration : IEntityTypeConfiguration<MovieLocation>
    {
        public void Configure(EntityTypeBuilder<MovieLocation> builder)
        {
            builder.HasKey(ml => new { ml.MovieId, ml.LocationId });

            builder.HasOne(ml => ml.Movie)
            .WithMany(m => m.Locations)
            .HasForeignKey(ml => ml.MovieId);

            builder.HasOne(ml => ml.Location)
                   .WithMany(l => l.Movies)
                   .HasForeignKey(ml => ml.LocationId);
            }
    }
}
