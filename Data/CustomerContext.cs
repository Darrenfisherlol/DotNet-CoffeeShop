using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }

        public CustomerContext ()
        {}

        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Customer> Customer { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=postgres;Username=postgres;Password=postgres"
            );
        }
    }
}