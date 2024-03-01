using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_7Habbits_App.Models;

public partial class HighHabitsContext : DbContext
{
    public HighHabitsContext()
    {
    }

    public HighHabitsContext(DbContextOptions<HighHabitsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=HighHabits.sqlite");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryID)
                ///.ValueGeneratedNever()   /// I got rid of this so we can add more (this method doesn't allow auto-increment for PK)
                .HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskID)
                ///.ValueGeneratedNever()   /// Same here
                .HasColumnName("TaskID");
            entity.Property(e => e.CategoryID).HasColumnName("CategoryID");
            entity.Property(e => e.Completed).HasColumnType("BOOLEAN");
            entity.Property(e => e.DueDate).HasColumnType("DATETIME");

            entity.HasOne(d => d.Category).WithMany(p => p.Tasks).HasForeignKey(d => d.CategoryID);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
