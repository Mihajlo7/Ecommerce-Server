using Microsoft.EntityFrameworkCore;
using Products.Core.DTOs;

namespace Products.Infrastructure
{
    public class ProductDbContext : DbContext
    {
        public DbSet<ProductFullRawDTO> ProductsFullRaw {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString =
                "Server=.;Database=master_products;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ProductFullRawDTO>()
                .ToView("GetAppleProducts");
        }
    }
}
