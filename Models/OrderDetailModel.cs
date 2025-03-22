using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }
        
        [Required]
        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        [ForeignKey("MenuItemId")]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        public OrderDetail()
        {}
        
        public OrderDetail (int orderId, int menuItemId, int quantity, decimal price)
        {
            this.OrderId = orderId;
            this.MenuItemId = menuItemId;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}


