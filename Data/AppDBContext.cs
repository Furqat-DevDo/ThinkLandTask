using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ThinkLand.DTO;

namespace ThinkLand.Data {
    public class AppDBContext : IdentityDbContext 
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base (options) { }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            Builder.Entity<Category>()
            .HasMany(p=>p.Products);
        }
    }
}