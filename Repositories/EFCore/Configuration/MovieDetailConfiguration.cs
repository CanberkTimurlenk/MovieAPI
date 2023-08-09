using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Configuration
{
    internal class MovieDetailConfiguration : IEntityTypeConfiguration<MovieDetail>
    {
        public void Configure(EntityTypeBuilder<MovieDetail> builder)
        {
            builder.HasKey(md => md.MovieId);

            builder.HasOne(md => md.Movie)
                   .WithOne(m => m.MovieDetail)
                   .HasForeignKey<MovieDetail>(md => md.MovieId);
                   
        }
    }
}
