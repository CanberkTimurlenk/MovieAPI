using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities.Junctions;

namespace Repositories.Concrete.EFCore.Configurations.Junctions
{
    public class MoviePersonsConfiguration : IEntityTypeConfiguration<MoviePerson>
    {
        public void Configure(EntityTypeBuilder<MoviePerson> builder)
        {
            builder.HasKey(mp => new { mp.MovieId, mp.PersonId });

            builder.HasOne(mp => mp.Movie)
                   .WithMany(m => m.Crew)
                   .HasForeignKey(mp => mp.MovieId);

            builder.HasOne(mp => mp.Person)
                   .WithMany(g => g.Movies)
                   .HasForeignKey(mp => mp.PersonId);
        }
    }
}
