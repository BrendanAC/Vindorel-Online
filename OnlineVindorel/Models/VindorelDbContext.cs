using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using OnlineVindorel.Models;
using System.Data.SqlClient;

namespace OnlineVindorel.Models
{
    public class VindorelDbContext : IdentityDbContext<Account>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=Can;Database=Vindorel_Online;Trusted_Connection=True;");
           
        }
            protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);

            



        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
  
        public DbSet<Towns> Towns { get; set;}
        public DbSet<Account> Account { get; set; }
        public DbSet<UserGameSettings> UserGameSettings { get; set; }
        public DbSet<UserTechnologyTree> UserTech { get; set; }
        public DbSet<TownArmy> Army { get; set; }
        public DbSet<TownPopulations> Population { get; set; }
        public DbSet<TownBuildings> Buildings { get; set; }
        public DbSet<Messages> Message { get; set; }
        public DbSet<UpgradeQueue> upgradeQueue { get; set; }
        public DbSet<Mission> Missions { get; set; }
        

    }
}
