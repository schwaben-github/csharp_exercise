using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class KnjiznicaContext : DbContext
{
    public KnjiznicaContext()
    {
    }

    public KnjiznicaContext(DbContextOptions<KnjiznicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KategorijeKnjiga> KategorijeKnjiga { get; set; }

    public virtual DbSet<Knjige> Knjige { get; set; }

    public virtual DbSet<MjestaStanovanja> MjestaStanovanja { get; set; }

    public virtual DbSet<Posudbe> Posudbe { get; set; }

    public virtual DbSet<Članovi> Članovi { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= BE2CG976\\SQLEXPRESS;Database= Knjiznica;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KategorijeKnjiga>(entity =>
        {
            entity.HasKey(e => e.KategorijaId).HasName("PK__kategori__487607FBC18393CB");

            entity.ToTable("kategorije_knjiga");

            entity.Property(e => e.KategorijaId)
                .ValueGeneratedNever()
                .HasColumnName("kategorija_id");
            entity.Property(e => e.Naziv)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("naziv");
        });

        modelBuilder.Entity<Knjige>(entity =>
        {
            entity.HasKey(e => e.KnjigaId).HasName("PK__knjige__77551C8049075E12");

            entity.ToTable("knjige");

            entity.Property(e => e.KnjigaId)
                .ValueGeneratedNever()
                .HasColumnName("knjiga_id");
            entity.Property(e => e.Autor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("autor");
            entity.Property(e => e.KategorijaId).HasColumnName("kategorija_id");
            entity.Property(e => e.Naslov)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("naslov");

            entity.HasOne(d => d.Kategorija).WithMany(p => p.Knjige)
                .HasForeignKey(d => d.KategorijaId)
                .HasConstraintName("FK__knjige__kategori__3E52440B");
        });

        modelBuilder.Entity<MjestaStanovanja>(entity =>
        {
            entity.HasKey(e => e.AdresaId).HasName("PK__mjesta_s__C6EBC6223DBBB601");

            entity.ToTable("mjesta_stanovanja");

            entity.Property(e => e.AdresaId)
                .ValueGeneratedNever()
                .HasColumnName("adresa_id");
            entity.Property(e => e.Država)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("država");
            entity.Property(e => e.Grad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("grad");
        });

        modelBuilder.Entity<Posudbe>(entity =>
        {
            entity.HasKey(e => e.PosudbaId).HasName("PK__posudbe__75FADAE99DC3CB8A");

            entity.ToTable("posudbe");

            entity.Property(e => e.PosudbaId)
                .ValueGeneratedNever()
                .HasColumnName("posudba_id");
            entity.Property(e => e.DatumPosudbe).HasColumnName("datum_posudbe");
            entity.Property(e => e.DatumVraćanja).HasColumnName("datum_vraćanja");
            entity.Property(e => e.KnjigaId).HasColumnName("knjiga_id");
            entity.Property(e => e.ČlanId).HasColumnName("član_id");

            entity.HasOne(d => d.Knjiga).WithMany(p => p.Posudbe)
                .HasForeignKey(d => d.KnjigaId)
                .HasConstraintName("FK__posudbe__knjiga___4222D4EF");

            entity.HasOne(d => d.Član).WithMany(p => p.Posudbe)
                .HasForeignKey(d => d.ČlanId)
                .HasConstraintName("FK__posudbe__član_id__412EB0B6");
        });

        modelBuilder.Entity<Članovi>(entity =>
        {
            entity.HasKey(e => e.ČlanId).HasName("PK__članovi__3A4FC5CEA06A4A0A");

            entity.ToTable("članovi");

            entity.Property(e => e.ČlanId)
                .ValueGeneratedNever()
                .HasColumnName("član_id");
            entity.Property(e => e.AdresaId).HasColumnName("adresa_id");
            entity.Property(e => e.Ime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ime");
            entity.Property(e => e.Prezime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prezime");

            entity.HasOne(d => d.Adresa).WithMany(p => p.Članovi)
                .HasForeignKey(d => d.AdresaId)
                .HasConstraintName("FK__članovi__adresa___3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
