using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class User : DbItem
    {
        [Required]
        public string Name { get; set; }
        
        [MinLength(2)]
        public string LastName { get; set; }

        [MinLength(10), MaxLength(12)]
        public string PhoneNo { get; set; }


        public List<Note> Notes { get; set; }



        public override void ClearNavigationProperties()
        {
            Notes = null;
        }
    }
}
