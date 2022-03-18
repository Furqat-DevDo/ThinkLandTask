using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ThinkLand.DTO;

namespace ThinkLand.DAL.Data {
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base (options) { }
        public virtual DbSet<Product> products { get; set; }
        public virtual DbSet<Category> categories { get; set; }
    }
}