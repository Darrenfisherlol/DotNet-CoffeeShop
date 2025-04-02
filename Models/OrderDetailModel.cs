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
        public Order? Order { get; set; }

        [Required]
        [ForeignKey("MenuItemId")]
        public int MenuItemId { get; set; }
        public MenuItem? MenuItem { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        
        public OrderDetail()
        {}
        
        public OrderDetail (int orderId, int menuItemId, int quantity)
        {
            this.OrderId = orderId;
            this.MenuItemId = menuItemId;
            this.Quantity = quantity;
        }
    }
}


