using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LBInfastructure.Context;

public partial class LB : DbContext
{
    public LB()
    {
    }

    public LB(DbContextOptions<LB> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;initial catalog=LB; User Id=Zaghlol;Password=123456789;App=EntityFramework;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
        });
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("Id");
            entity.Property(e => e.PersonName)
                .HasMaxLength(50)
                .HasColumnName("PersonName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("Email");
            entity.Property(e => e.Phone)
                .HasColumnType("int")
                .HasColumnName("Phone");
            entity.Property(e => e.Grad)
                .HasColumnName("Grad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
