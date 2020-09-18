using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagementAPI.Models;

namespace StoreManagement.Models
{
    public class StoreContext : IdentityDbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}