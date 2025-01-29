using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class SaleContext : DbContext
    {
        public SaleContext(DbContextOptions<SaleContext> options) : base(options) { }

        public SaleContext ()
        {}

        public DbSet<Sale> Sale { get; set; } 
        public DbSet<Customer> Customer { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=postgres;Username=postgres;Password=postgres"
            );
        }
    }
}