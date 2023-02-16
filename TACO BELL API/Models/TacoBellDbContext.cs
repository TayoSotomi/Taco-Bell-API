using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TACO_BELL_API.Models;

public partial class TacoBellDbContext : DbContext
{
    public TacoBellDbContext()
    {
    }

    public TacoBellDbContext(DbContextOptions<TacoBellDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Burrito> Burritos { get; set; }

    public virtual DbSet<Drink> Drinks { get; set; }

    public virtual DbSet<Taco> Tacos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress01;Database=TacoBellDb;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Burrito>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Burrito__3214EC2755F0369B");

            entity.ToTable("Burrito");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Drink>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Drink__3214EC2726584D79");

            entity.ToTable("Drink");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Taco>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Taco__3214EC27AF7FD1E9");

            entity.ToTable("Taco");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
