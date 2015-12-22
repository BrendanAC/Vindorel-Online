using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using VindorelOnline.Models;
using Microsoft.Data.Entity.Metadata;
using Microsoft.AspNet.Identity;
using Microsoft.Framework.DependencyInjection;

namespace GameVindorel.Models
{
    public class ApplicationDbContext : IdentityDbContext<VindorelUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TownBuildings>(entity =>
            {
                entity.HasKey(e => e.BuildingsID);

                entity.HasOne(d => d.Town).WithMany(p => p.TownBuildings).HasForeignKey(d => d.TownID).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<TownPopulations>(entity =>
            {
                entity.HasKey(e => e.PopulationID);

                entity.HasOne(d => d.Town).WithMany(p => p.TownPopulations).HasForeignKey(d => d.TownID).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Towns>(entity =>
            {
                entity.HasKey(e => e.TownID);

                entity.Property(e => e.LastUPDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TownName).HasMaxLength(30);

            });
        }
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        public virtual DbSet<TownBuildings> TownBuildings { get; set; }
        public virtual DbSet<TownPopulations> TownPopulations { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<VindorelUser> UserAccounts { get; set; }
    }


    
}
