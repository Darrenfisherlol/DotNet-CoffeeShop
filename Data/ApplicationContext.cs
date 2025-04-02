using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }

        // ----RELATIONSHIP MAPPING------
        
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // CUSTOMER TO ORDER
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // COFFEE TO MENUITEM
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Coffee)
                .WithMany(c => c.MenuItems)
                .HasForeignKey(m => m.CoffeeId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // ORDER ---> ORDERDETAIL <--- MENU ITEM
            
            // Composite Key for Join Table
            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.MenuItemId }); 
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                // Navigation Property in order
                .WithMany(o => o.OrderDetails)
                // Fk
                .HasForeignKey(od => od.OrderId);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.MenuItem)
                // Navigation Property in order
                .WithMany(o => o.OrderDetails)
                // Fk
                .HasForeignKey(od => od.MenuItemId);
            
        }
        
        // ----------
        public ApplicationDbContext()
        {
        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connection string should be stored in another file
            optionsBuilder.UseNpgsql(
                "Host=localhost;Database=postgres;Username=postgres;Password=postgres"
            );
        }
    }
}