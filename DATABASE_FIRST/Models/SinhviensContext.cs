using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DATABASE_FIRST.Models;

public partial class SinhviensContext : DbContext
{
    public SinhviensContext()
    {
    }

    public SinhviensContext(DbContextOptions<SinhviensContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lop> Lops { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=VICTUS;Database=SINHVIENS;Trusted_Connection=True;TrustServerCertificate=True");*/

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa).HasName("PK__KHOA__22F417700797429D");

            entity.ToTable("KHOA");

            entity.Property(e => e.Makhoa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(30)
                .HasColumnName("TENKHOA");
        });

        modelBuilder.Entity<Lop>(entity =>
        {
            entity.HasKey(e => e.Malop).HasName("PK__LOP__7A3DE2115DEBE811");

            entity.ToTable("LOP");

            entity.Property(e => e.Malop)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Tenlop)
                .HasMaxLength(30)
                .HasColumnName("TENLOP");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__SINHVIEN__60228A2883513511");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Masv)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MASV");
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Hoten)
                .HasMaxLength(100)
                .HasColumnName("HOTEN");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Malop)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("MALOP");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK__SINHVIEN__MAKHOA__3B75D760");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK__SINHVIEN__MALOP__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
