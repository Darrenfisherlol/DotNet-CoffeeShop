using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        
        public Customer? Customer { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        
        public Order() {}
        
        public Order (int customerId)
        {
            this.CustomerId = customerId;
        }
        
    }
}


