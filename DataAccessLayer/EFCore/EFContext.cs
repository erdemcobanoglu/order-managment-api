using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EFCore
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        { 

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<OrderDetail>()
                    .HasKey(od => new { od.ProductId, od.OrderId });

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderAddress)
                .HasMaxLength(250);

            #region CustomerConfiguration
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired(true);


            modelBuilder.Entity<Customer>()
                .Property(c => c.Address)
                .HasMaxLength(250)
                .IsRequired(true); 
            #endregion

            #region ProductConfiguration
            modelBuilder.Entity<Product>()
                  .Property(p => p.Description)
                  .HasMaxLength(1000)
                  .IsRequired(false);

            modelBuilder.Entity<Product>()
                .Property(p => p.Barcode)
                .HasMaxLength(250)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.QuantityPerUnit)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true);


            #endregion
        }
    }
}
