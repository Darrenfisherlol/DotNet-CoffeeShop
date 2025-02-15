

namespace WebApplication2.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public Sale Sale { get; set; } 
        public int CoffeeId { get; set; }
        public Coffee Coffee { get; set; } 
        public int Quantity { get; set; }
        
        // ORM Constructor
        public OrderDetail()
        {
        }
        
        public OrderDetail (int id, int saleId, int coffeeId, int quantity)
        {
            this.Id = id;
            this.SaleId = saleId;
            this.CoffeeId = coffeeId;
            this.Quantity = quantity;
        }
    }
}


