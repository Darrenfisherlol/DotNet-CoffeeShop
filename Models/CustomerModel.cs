using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(100)]
        public string LastName { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JoinDate { get; set; }
        
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        
        public Customer(){}
        
        public Customer(string firstName, string lastName, string email, string phoneNumber, DateTime joinDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Phone = phoneNumber;
            this.JoinDate = joinDate;
        }
    
    }
    
}

