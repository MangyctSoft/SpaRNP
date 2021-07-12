using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpaRNP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaRNP.Context.EntityConfiguration
{
    public class AnalysisUsersEntityTypeConfiguration : IEntityTypeConfiguration<AnalysisUser>
    {
        public void Configure(EntityTypeBuilder<AnalysisUser> builder)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.ToTable("AnalysisUsers");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.RegisteredAt)
            .IsRequired();

            builder.Property(ci => ci.ActiveAt)
            .IsRequired();

        }
    }
}