

namespace WebApplication2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CoffeeId { get; set; }
        public string OrderDateTime { get; set; }
    
        public Order (int id, int userId, string coffeeId, string dateTime)
        {
            this.Id = id;
            this.UserId = userId;
            this.CoffeeId = coffeeId;
            this.OrderDateTime = dateTime;
        }
    }
}

