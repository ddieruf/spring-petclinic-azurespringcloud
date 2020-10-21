using System;
using Microsoft.EntityFrameworkCore;
using spring_petclinic_customers_api.DTOs;

namespace spring_petclinic_customers_api.Data
{
  public partial class CustomersContext : DbContext
  {
    public CustomersContext()
    {
    }

    public CustomersContext(DbContextOptions<CustomersContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Owner> Owners { get; set; }
    public virtual DbSet<Pet> Pets { get; set; }
    public virtual DbSet<PetType> PetTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
//      if (!optionsBuilder.IsConfigured)
//      {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//        optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1433;Initial Catalog=petclinic;User Id=sa;Password=cccxcccc");
//      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Owner>(entity =>
      {
        entity.ToTable("owners");

        entity.HasIndex(e => e.LastName)
            .HasName("owners_last_name")
            ;

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Address)
            .HasColumnName("address")
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.City)
            .HasColumnName("city")
            .HasMaxLength(80)
            .IsUnicode(false);

        entity.Property(e => e.FirstName)
            .HasColumnName("first_name")
            .HasMaxLength(30)
            .IsUnicode(false);

        entity.Property(e => e.LastName)
            .HasColumnName("last_name")
            .HasMaxLength(30)
            .IsUnicode(false);

        entity.Property(e => e.Telephone)
            .HasColumnName("telephone")
            .HasMaxLength(20)
            .IsUnicode(false);
      });

      modelBuilder.Entity<Pet>(entity =>
      {
        entity.ToTable("pets");

        entity.HasIndex(e => e.Name)
            //.HasName("pets_name")
            ;

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.BirthDate)
            .HasColumnName("birth_date")
            .HasColumnType("date");

        entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(30)
            .IsUnicode(false);

        entity.Property(e => e.OwnerId).HasColumnName("owner_id");

        entity.Property(e => e.TypeId).HasColumnName("type_id");

        entity.HasOne(d => d.Owner)
            .WithMany(p => p.Pets)
            .HasForeignKey(d => d.OwnerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_pets_owners");

        entity.HasOne(d => d.PetType)
            //.WithMany(p => p.Pets)
            //.HasForeignKey(d => d.TypeId)
           // .OnDelete(DeleteBehavior.ClientSetNull)
            //.HasConstraintName("fk_pets_types")
            ;
      });

      modelBuilder.Entity<PetType>(entity =>
      {
        entity.ToTable("types");

        entity.HasIndex(e => e.Name)
            //.HasName("types_name")
            ;

        entity.Property(e => e.Id).HasColumnName("id");

        entity.Property(e => e.Name)
            .HasColumnName("name")
            .HasMaxLength(80)
            .IsUnicode(false);
      });

      OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
  }
}
