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
    public class AdoptantiConfiguration : IEntityTypeConfiguration<Adoptanti>
    {
        public void Configure(EntityTypeBuilder<Adoptanti> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Prenume)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30);

            builder.Property(x => x.Telefon)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
