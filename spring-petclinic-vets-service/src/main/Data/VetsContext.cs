using System;
using Microsoft.EntityFrameworkCore;
using spring_petclinic_vets_api.DTOs;

namespace spring_petclinic_vets_api.Data
{
  public partial class VetsContext : DbContext
  {
    public VetsContext()
    {
    }

    public VetsContext(DbContextOptions<VetsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Specialty> Specialties { get; set; }
    public virtual DbSet<VetSpecialty> VetSpecialties { get; set; }
    public virtual DbSet<Vet> Vets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
     
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<Specialty>(entity =>
      {
        entity.ToTable("specialties");

        entity.HasIndex(e => e.Name)
            .HasName("specialties_name");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(80)
            .IsUnicode(false);
      });

      modelBuilder.Entity<VetSpecialty>(entity =>
      {
        //entity.HasNoKey();

        entity.ToTable("vet_specialties");

        entity.Property(e => e.VetSpecialtyId).HasColumnName("id");

        entity.Property(e => e.SpecialtyId).HasColumnName("specialty_id");

        entity.Property(e => e.VetId).HasColumnName("vet_id");

        entity.HasOne(d => d.Specialty)
            .WithMany()
            .HasForeignKey(d => d.SpecialtyId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_vet_specialties_specialties");

        entity.HasOne(d => d.Vet)
            .WithMany()
            .HasForeignKey(d => d.VetId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_vet_specialties_vets");
      });

      modelBuilder.Entity<Vet>(entity =>
      {
        entity.ToTable("vets");

        entity.HasIndex(e => e.LastName)
            .HasName("vets_last_name");

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(30)
            .IsUnicode(false);

        entity.Property(e => e.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(30)
            .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
