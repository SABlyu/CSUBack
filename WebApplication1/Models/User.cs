using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [MinLength(2)]
        public string LastName { get; set; }

        [MinLength(10), MaxLength(12)]
        public string PhoneNo { get; set; }
    }
}
