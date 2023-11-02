using System.ComponentModel.DataAnnotations;

namespace PlayerTracker.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Player>? Players { get; set; }
    }
}
