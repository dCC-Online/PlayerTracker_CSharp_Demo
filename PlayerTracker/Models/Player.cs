using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PlayerTracker.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ForeignKey("Team")]        
        public int TeamId { get; set; }
        [Display(Name = "Team Name")]
        public Team Team { get; set; }

    }
}
