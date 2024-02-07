using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace flightmvc.Models;

public partial class Ace52024Context : DbContext
{
    public Ace52024Context()
    {
    }

    public Ace52024Context(DbContextOptions<Ace52024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<KritikaBooking> KritikaBookings { get; set; }

    public virtual DbSet<KritikaCustomer> KritikaCustomers { get; set; }

    public virtual DbSet<KritikaFlight> KritikaFlights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEVSQL.Corp.local;Database=ACE 5- 2024;Trusted_Connection=True;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KritikaBooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__KritikaB__73951AEDFD2904D7");

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Customer).WithMany(p => p.KritikaBookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("fkx");

            entity.HasOne(d => d.Flight).WithMany(p => p.KritikaBookings)
                .HasForeignKey(d => d.FlightId)
                .HasConstraintName("fkf");
        });

        modelBuilder.Entity<KritikaCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__KritikaC__A4AE64D8E83AFF86");

            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.CustomerName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Loc)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        modelBuilder.Entity<KritikaFlight>(entity =>
        {
            entity.HasKey(e => e.FlightId).HasName("PK__KritikaF__8A9E14EEF0F1830F");

            entity.Property(e => e.FlightId).ValueGeneratedNever();
            entity.Property(e => e.Airline)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Destination)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FlightName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Source)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
