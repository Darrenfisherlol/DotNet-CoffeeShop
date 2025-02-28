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
        [StringLength(100)]
        public string Type { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public MenuItem()
        {
        }
        
        public MenuItem (int id, string name, string description, string type, decimal price)
        {
            this.MenuItemId = id;
            this.Name = name;
            this.Description = description;
            this.Type = type;
            this.Price = price;
        }
    }
}

