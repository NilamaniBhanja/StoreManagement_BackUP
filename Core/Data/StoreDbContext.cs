using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagementAPI.Models;

namespace StoreManagement.Core.Data
{
    public class StoreDbContext : IdentityDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCost> ProductCost { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Supplier> Supplier { get; set; }        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);            
        }
    }
}