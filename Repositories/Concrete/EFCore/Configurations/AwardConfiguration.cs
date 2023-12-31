﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Concrete.Entities;

namespace Repositories.Concrete.EFCore.Configuration
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.ToTable(m => m.HasTrigger("TRG_PreventDuplicateAwards"));

            builder.HasKey(a => new { a.AwardTypeId, a.MovieId });

            builder.HasOne(a => a.Movie)
                   .WithMany(m => m.Awards)
                   .HasForeignKey(a => a.MovieId);

            builder.HasOne(a => a.AwardType)
                   .WithMany(at => at.Awards)
                   .HasForeignKey(a => a.AwardTypeId);

        }
    }
}