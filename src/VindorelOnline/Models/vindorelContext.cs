using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace VindorelOnline.Models
{
    public partial class vindorelContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=Can;Database=vindorel;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TownBuildings>(entity =>
            {
                entity.HasKey(e => e.BuildingsID);

                entity.HasOne(d => d.Town).WithMany(p => p.TownBuildings).HasForeignKey(d => d.TownID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TownPopulations>(entity =>
            {
                entity.HasKey(e => e.PopulationID);

                entity.HasOne(d => d.Town).WithMany(p => p.TownPopulations).HasForeignKey(d => d.TownID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Towns>(entity =>
            {
                entity.HasKey(e => e.TownID);

                entity.Property(e => e.LastUPDATE).HasColumnType("smalldatetime");

                entity.Property(e => e.TownName).HasMaxLength(30);

                entity.HasOne(d => d.User).WithMany(p => p.Towns).HasForeignKey(d => d.UserID).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserAccounts>(entity =>
            {
                entity.HasKey(e => e.UserID);

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginMail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginPassword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RegisterDate).HasColumnType("smalldatetime");

                entity.Property(e => e.UserJob)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UserRace)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<sysdiagrams>(entity =>
            {
                entity.HasKey(e => e.diagram_id);

                entity.Property(e => e.definition).HasColumnType("varbinary");
            });
        }

        public virtual DbSet<TownBuildings> TownBuildings { get; set; }
        public virtual DbSet<TownPopulations> TownPopulations { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<UserAccounts> UserAccounts { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}