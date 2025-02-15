

namespace WebApplication2.Models
{
    public class Coffee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Temp { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Coffee()
        {
        }
        public Coffee (int id, string name, string category, string temp, string description, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Category = category;
            this.Temp = temp;
            this.Description = description;
            this.Price = price;
        }
    }
}

