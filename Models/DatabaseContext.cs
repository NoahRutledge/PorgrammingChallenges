using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeChecker.Models;

public partial class DatabaseContext : DbContext
{
    public DbSet<ChallengeFullInfo> ChallengeData { get; set; }
    public DbSet<ChallengeTestCase> ChallengeTestCases { get; set; }

    public DatabaseContext() { }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChallengeFullInfo>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AuthorName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ChallengeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<ChallengeTestCase>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Id).HasColumnName("ID");

            entity.HasOne(d => d.IdNavigation).WithMany()
                .HasForeignKey(d => d.Id)
                .HasConstraintName("FK_ChallengeID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
