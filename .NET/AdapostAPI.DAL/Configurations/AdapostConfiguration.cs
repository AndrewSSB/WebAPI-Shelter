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
    public class AdapostConfiguration : IEntityTypeConfiguration<Adapost>
    {
        public void Configure(EntityTypeBuilder<Adapost> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(40)")
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(x => x.Telefon)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10);

            //builder.HasOne(x => x.Location)//pentru 1:1
            //    .WithOne(x => x.Adapost)
            //    .HasForeignKey<Adapost>(x => x.LocationId);
        }
    }
}
