using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities.Junctions;

namespace Repositories.Concrete.EFCore.Configurations.Junctions
{
    public class MovieLanguagesConfiguration : IEntityTypeConfiguration<MovieLanguage>
    {
        public void Configure(EntityTypeBuilder<MovieLanguage> builder)
        {
            builder.HasKey(ml => new { ml.MovieId, ml.LanguageId });


            builder.HasOne(ml => ml.Movie)
            .WithMany(m => m.Languages)
            .HasForeignKey(ml => ml.MovieId);

            builder.HasOne(ml => ml.Language)
                   .WithMany(l => l.Movies)
                   .HasForeignKey(ml => ml.LanguageId);
        }
    }
}
