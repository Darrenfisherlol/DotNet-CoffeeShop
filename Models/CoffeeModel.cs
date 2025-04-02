using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Coffee
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CoffeeId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
 
        [Required]
        [StringLength(100)]
        public string RoastType { get; set; }
        
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
        
        public Coffee()
        {}
        
        public Coffee (string name, string description, string roast)
        {
            this.Name = name;
            this.Description = description;
            this.RoastType = roast;
        }
    }
}

