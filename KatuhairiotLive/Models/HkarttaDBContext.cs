using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KatuhairiotLive.Models
{
    public partial class HkarttaDBContext : DbContext
    {
        public HkarttaDBContext()
        {
        }

        public HkarttaDBContext(DbContextOptions<HkarttaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<URoute> URoutes { get; set; } = null!;
        public virtual DbSet<Username> Usernames { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<URoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK__uRoute__80979AAD84545CD8");

                entity.ToTable("uRoute");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.Property(e => e.UserRoute)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("userRoute");
            });

            modelBuilder.Entity<Username>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__Username__CB9A1CDFE6066FD2");

                entity.ToTable("Username");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.FavRoute)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("favRoute");

                entity.Property(e => e.Routeid).HasColumnName("routeid");

                entity.Property(e => e.Username1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Usernames)
                    .HasForeignKey(d => d.Routeid)
                    .HasConstraintName("FK__Username__routei__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
