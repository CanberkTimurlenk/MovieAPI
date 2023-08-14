using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities;

namespace Repositories.Concrete.EFCore.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.HasKey(a => new { a.Year, a.AwardTypeId });
        }
    }
}
