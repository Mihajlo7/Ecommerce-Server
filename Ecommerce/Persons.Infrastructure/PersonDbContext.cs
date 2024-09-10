using Microsoft.EntityFrameworkCore;
using Persons.Core.DTOs.GetPersonByEmail;
using Persons.Core.DTOs.Registration;

namespace Persons.Infrastructure
{
    public class PersonDbContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = 
                "Server=.;Database=master_persons;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonByEmailRawResponse>()
                .HasNoKey()
                .ToView("ProductDTO");
        }

            
    }
}
