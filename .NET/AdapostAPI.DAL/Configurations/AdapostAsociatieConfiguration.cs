using AdapostAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Configurations
{
    public class AdapostAsociatieConfiguration : IEntityTypeConfiguration<AdapostAsociatie>
    {
        public void Configure(EntityTypeBuilder<AdapostAsociatie> builder)
        {
            builder.HasOne(x => x.Adapost) //configurare prin builder a unui foreign key
                .WithMany(x => x.AdapostAsociaties)
                .HasForeignKey(x => x.AdapostId);

            builder.HasOne(x => x.Asociatie)
                .WithMany(x => x.AdapostAsociaties)
                .HasForeignKey(x => x.AsociatieId);

            builder.Property(x => x.SumaDonata)
                .HasColumnType("decimal(7,2)");
        }
    }
}
