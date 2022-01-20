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
    public class AdapostVizitatorConfiguration : IEntityTypeConfiguration<AdapostVizitator>
    {
        public void Configure(EntityTypeBuilder<AdapostVizitator> builder)
        {
            builder.HasOne(x => x.Adapost) //configurare prin builder a unui foreign key
                .WithMany(x => x.AdapostVizitators)
                .HasForeignKey(x => x.AdapostId);

            builder.HasOne(x => x.Vizitator)
                .WithMany(x => x.AdapostVizitators)
                .HasForeignKey(x => x.VizitatorId);
        }
    }
}
