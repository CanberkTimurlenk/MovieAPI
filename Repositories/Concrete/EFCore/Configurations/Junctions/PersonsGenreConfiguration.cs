using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Domains.Junctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EFCore.Configurations.Junctions
{
    public class PersonGenresConfiguration : IEntityTypeConfiguration<PersonGenre>
    {
        public void Configure(EntityTypeBuilder<PersonGenre> builder)
        {
            builder.HasKey(pg => new { pg.PersonId, pg.GenreId });

            builder.HasOne(pg => pg.Person)
                   .WithMany(p => p.Genres)
                   .HasForeignKey(pg => pg.PersonId);

            builder.HasOne(pg => pg.Genre)
                   .WithMany(g => g.Persons)
                   .HasForeignKey(pg => pg.GenreId);

        }
    }
}
