using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagementAPI.Models;

namespace StoreManagement.Core.Data
{
    public class StoreDbContext : IdentityDbContext
    {
        // public DbSet<Brand> Brands { get; set; }
        // public DbSet<Measurement> Measurements { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}