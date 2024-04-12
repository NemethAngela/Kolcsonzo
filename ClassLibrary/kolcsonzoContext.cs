using System;
using System.Collections.Generic;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary
{
    public partial class kolcsonzoContext : DbContext
    {
        public kolcsonzoContext()
        {
        }

        public kolcsonzoContext(DbContextOptions<kolcsonzoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Kolcsonzesek> Kolcsonzeseks { get; set; } = null!;
        public virtual DbSet<Kolcsonzok> Kolcsonzoks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;password=titok;database=kolcsonzo", ServerVersion.Parse("10.11.2-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Kolcsonzesek>(entity =>
            {
                entity.ToTable("kolcsonzesek");

                entity.HasIndex(e => e.KolcsonzokId, "kolcsonzokId");

                entity.Property(e => e.Id)
                    .HasColumnType("int(32)")
                    .HasColumnName("id");

                entity.Property(e => e.Cim)
                    .HasMaxLength(100)
                    .HasColumnName("cim");

                entity.Property(e => e.Iro)
                    .HasMaxLength(100)
                    .HasColumnName("iro");

                entity.Property(e => e.KolcsonzokId)
                    .HasColumnType("int(32)")
                    .HasColumnName("kolcsonzokId");

                entity.Property(e => e.Mufaj)
                    .HasMaxLength(100)
                    .HasColumnName("mufaj");

                entity.HasOne(d => d.Kolcsonzok)
                    .WithMany(p => p.Kolcsonzeseks)
                    .HasForeignKey(d => d.KolcsonzokId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kolcsonzesek_ibfk_1");
            });

            modelBuilder.Entity<Kolcsonzok>(entity =>
            {
                entity.ToTable("kolcsonzok");

                entity.Property(e => e.Id)
                    .HasColumnType("int(32)")
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nev)
                    .HasMaxLength(100)
                    .HasColumnName("nev");

                entity.Property(e => e.SzulIdo)
                    .HasMaxLength(100)
                    .HasColumnName("szulIdo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
