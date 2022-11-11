using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Findergers1._0.Models
{
    public partial class DesappContext : DbContext
    {
        public DesappContext()
        {
        }

        public DesappContext(DbContextOptions<DesappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LoginAndRegister> LoginAndRegisters { get; set; } = null!;
        public virtual DbSet<Missing> Missings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SEBAS;Database=Desapp;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoginAndRegister>(entity =>
            {
                entity.ToTable("Login_and_Register");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FristName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("frist_name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Missing>(entity =>
            {
                entity.HasKey(e => e.IdMissing)
                    .HasName("PK_Desapp");

                entity.ToTable("Missing");

                entity.Property(e => e.IdMissing).HasColumnName("Id_Missing");

                entity.Property(e => e.AgeMissing).HasColumnName("Age__Missing");

                entity.Property(e => e.DateMissing)
                    .HasColumnType("datetime")
                    .HasColumnName("Date__Missing");

                entity.Property(e => e.DescriptionMissing)
                    .IsUnicode(false)
                    .HasColumnName("Description_Missing");

                entity.Property(e => e.ImageMissing)
                    .IsUnicode(false)
                    .HasColumnName("Image_Missing");

                entity.Property(e => e.LastlocationMissing)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("lastlocation_Missing");

                entity.Property(e => e.NameMissing)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Name__Missing");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
