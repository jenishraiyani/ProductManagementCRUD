using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace ProductManagmentCRUD.Models
{
    public class ProductContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddresss> CustomerAddresses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Product>()
                .HasRequired<Category>(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey<int>(s => s.CategoryId);


            modelBuilder.Entity<Orders>()
               .HasRequired<Customer>(o => o.Customers)
               .WithMany(c => c.Orders)
               .HasForeignKey<int>(s => s.CustomerId);

            // One to One

            modelBuilder.Entity<Customer>().HasOptional(s => s.Address).WithRequired(a => a.Customer);

            // Many to Many
            modelBuilder.Entity<Orders>()
             .HasMany<Product>(o => o.Products)
             .WithMany(p => p.Orders)
             .Map(od =>
             {
                 od.MapLeftKey("OrdersId");
                 od.MapRightKey("ProductId");
                 od.ToTable("OrderDetails");
             });

        }
    }
}