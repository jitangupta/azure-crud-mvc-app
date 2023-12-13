using System;
using System.Collections.Generic;
using AzureCrudMvcApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AzureCrudMvcApp.Context;

public partial class AzureCrudMvcAppDbContext : DbContext
{
    public AzureCrudMvcAppDbContext()
    {
    }

    public AzureCrudMvcAppDbContext(DbContextOptions<AzureCrudMvcAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=dbName");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07F28581EB");

            entity.ToTable("Department");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC073D030F5E");

            entity.ToTable("Employee");

            entity.Property(e => e.DateOfJoining).HasColumnType("smalldatetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .HasConstraintName("FK__Employee__DeptId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
