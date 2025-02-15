

namespace WebApplication2.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 
        public int Quantity { get; set; }
        public DateTime OrderDateTime { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        // ORM Constructor
        public Sale()
        {
        }
        public Sale (int id, int customerId, int quantity, DateTime orderDateTime)
        {
            this.Id = id;
            this.CustomerId = customerId;
            this.Quantity = quantity;
            this.OrderDateTime = orderDateTime;
        }
        
    }
}


