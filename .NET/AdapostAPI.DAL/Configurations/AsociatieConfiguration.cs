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
    public class AsociatieConfiguration : IEntityTypeConfiguration<Asociatie>
    {
        public void Configure(EntityTypeBuilder<Asociatie> builder)
        {
            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Adresa)
                .HasColumnType("nvarchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x =>x.Email)
                .HasColumnType("nvarchar(40)")
                .HasMaxLength(40)
                .IsRequired();
            
            builder.Property(x => x.Telefon)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
