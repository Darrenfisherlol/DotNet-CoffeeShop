

namespace WebApplication2.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public User(int id, string fistName, string lastName, string email)
        {
            this.Id = id;
            this.FistName = fistName;
            this.LastName = lastName;
            this.Email = email;
        }
    
    }
    
}

