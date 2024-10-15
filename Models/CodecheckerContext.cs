using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CodeChecker.Models;

public partial class CodecheckerContext : DbContext
{
    public CodecheckerContext()
    {
    }

    public CodecheckerContext(DbContextOptions<CodecheckerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChallengeDatum> ChallengeData { get; set; }

    public virtual DbSet<ChallengeTestCase> ChallengeTestCases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChallengeDatum>(entity =>
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
