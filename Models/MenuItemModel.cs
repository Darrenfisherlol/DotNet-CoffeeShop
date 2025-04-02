using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class MenuItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuItemId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
        
        [Required]
        [ForeignKey("CoffeeId")]
        public int CoffeeId { get; set; }
        public Coffee? Coffee { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        
        public MenuItem() {}
        
        public MenuItem (string name, string description, int coffeeId, string type, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.CoffeeId = coffeeId;
            this.Type = type;
            this.Price = price;
        }
        
    }
}

