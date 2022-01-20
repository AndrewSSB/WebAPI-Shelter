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
    public class EmployeerConfiguration : IEntityTypeConfiguration<Employeer>
    {
        public void Configure(EntityTypeBuilder<Employeer> builder)
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

            builder.Property(x => x.Salariu)
                .HasColumnType("decimal(7,2)")
                .IsRequired();

            builder.Property(x => x.Post)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
