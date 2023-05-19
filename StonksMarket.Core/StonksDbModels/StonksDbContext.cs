using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StonksMarket.Core.StonksDbModels;

public partial class StonksDbContext : DbContext
{
    public StonksDbContext()
    {
    }

    public StonksDbContext(DbContextOptions<StonksDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserStock> UserStocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Database=StonksDB;User Id=StonksUser;Password=grr100");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TRANSACTIONS_pkey");

            entity.ToTable("TRANSACTIONS");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("USER_TRANSACTION");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("USER_pkey");

            entity.ToTable("USER");

            entity.Property(e => e.UserId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<UserStock>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("USER_STOCK_pkey");

            entity.ToTable("USER_STOCK");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.UserStocks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("USER_STOCK");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
