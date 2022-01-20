using AdapostAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL.Configurations
{
    class VizitatorConfiguration : IEntityTypeConfiguration<Vizitator>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Vizitator> builder)
        {
            builder.Property(x => x.Nume)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Prenume)
                .HasColumnType("nvarchar(30)")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
