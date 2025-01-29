

namespace WebApplication2.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CoffeeId { get; set; }
        public int Quantity { get; set; }
        public string OrderDateTime { get; set; }
    
        public Sale (int id, int userId, string coffeeId, int quantity, string dateTime)
        {
            this.Id = id;
            this.UserId = userId;
            this.CoffeeId = coffeeId;
            this.Quantity = quantity;
            this.OrderDateTime = dateTime;
        }
    }
}

