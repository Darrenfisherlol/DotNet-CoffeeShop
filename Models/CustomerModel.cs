

namespace WebApplication2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<Sale> Sales { get; set; }

        
        public Customer()
        {
            
        }
        public Customer(int id, string fistName, string lastName, string email, string phoneNumber)
        {
            this.Id = id;
            this.FistName = fistName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phoneNumber;
        }
    
    }
    
}

