using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            //  Shadow Property
            builder.Property<DateTime?>("LastModified").HasColumnType("date");

            builder.Property(b => b.ReleaseDate).HasColumnType("date");

        }
    }
}
