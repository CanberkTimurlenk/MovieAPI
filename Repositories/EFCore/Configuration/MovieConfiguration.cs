using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities;

namespace Repositories.EFCore.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //  Shadow Property
            builder.Property<DateTime?>("LastModified").HasColumnType("date");

            builder.Property(b => b.ReleaseDate).HasColumnType("date");

            builder.ToTable(m => m.HasTrigger("trg_UpdateMovies"));

        }
    }
}
