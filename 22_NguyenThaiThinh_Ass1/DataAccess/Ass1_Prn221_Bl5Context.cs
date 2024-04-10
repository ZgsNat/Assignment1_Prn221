using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace _22_NguyenThaiThinh_Ass1.DataAccess
{
    public partial class Ass1_Prn221_Bl5Context : DbContext
    {
        public Ass1_Prn221_Bl5Context()
        {
        }

        public Ass1_Prn221_Bl5Context(DbContextOptions<Ass1_Prn221_Bl5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("Member");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Freight).HasColumnType("money");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.RequiredDate).HasColumnType("datetime");

                entity.Property(e => e.ShippedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Order__MemberId__2B3F6F97");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK__OrderDet__08D097A3B9A86AC5");

                entity.ToTable("OrderDetail");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Order__36B12243");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__Produ__37A5467C");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.Property(e => e.Weight)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
