using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RepositoryDesignPattern.Models.Models
{
    public partial class QAContext : DbContext
    {
        public QAContext()
        {
        }

        public QAContext(DbContextOptions<QAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblInvoice> TblInvoices { get; set; } = null!;
        public virtual DbSet<TblPerson> TblPeople { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblInvoice>(entity =>
            {
                entity.ToTable("tbl_Invoice", "Test Software Developer");

                entity.Property(e => e.Amount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Date)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPerson>(entity =>
            {
                entity.ToTable("tbl_Person", "Test Software Developer");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SecondLastName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdInvoiceNavigation)
                    .WithMany(p => p.TblPeople)
                    .HasForeignKey(d => d.IdInvoice)
                    .HasConstraintName("FK_IdInvoice");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
