using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities;

namespace Repositories.Concrete.EFCore.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasOne(p => p.Actor)
                   .WithOne(a => a.Person)
                   .HasForeignKey<Actor>(a => a.PersonId);

            builder.HasOne(p => p.Director)
                   .WithOne(d => d.Person)
                   .HasForeignKey<Director>(d => d.PersonId);


        }
    }
}
