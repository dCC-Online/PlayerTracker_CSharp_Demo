using PlayerTracker.Models;

namespace PlayerTracker.ViewModels
{
    public class PlayerWithTeams
    {
        public Player Player { get; set; }
        public IEnumerable<Team> Teams { get; set; }
    }
}
