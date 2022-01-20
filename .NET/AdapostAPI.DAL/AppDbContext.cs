using AdapostAPI.DAL.Configurations;
using AdapostAPI.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapostAPI.DAL
{
    public class AppDbContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Adapost> Adaposts { get; set; }
        public DbSet<Employeer> Employeers { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Adoptanti> Adoptantis { get; set; }
        public DbSet<Vizitator> Vizitators { get; set; }
        public DbSet<AdapostVizitator> AdapostVizitators { get; set; }
        public DbSet<Asociatie> Asociaties { get; set; }
        public DbSet<AdapostAsociatie> AdapostAsociaties { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new AdapostConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeerConfiguration());
            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new AdoptantiConfiguration());
            modelBuilder.ApplyConfiguration(new VizitatorConfiguration());
            modelBuilder.ApplyConfiguration(new AdapostVizitatorConfiguration());
            modelBuilder.ApplyConfiguration(new AsociatieConfiguration());
            modelBuilder.ApplyConfiguration(new AdapostAsociatieConfiguration());
        }
    }
}
