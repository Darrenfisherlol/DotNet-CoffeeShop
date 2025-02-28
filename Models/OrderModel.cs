using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        
        public Customer Customer { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        
        public Order()
        {
        }
        
        public Order (int id, int customerId, Customer customer, DateTime orderDate, decimal price)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.Customer = customer;
            this.OrderDate = orderDate;
            this.Price = price;
        }
    }
}


