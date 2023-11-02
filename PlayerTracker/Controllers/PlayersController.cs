using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerTracker.Data;
using PlayerTracker.Models;
using PlayerTracker.ViewModels;

namespace PlayerTracker.Controllers
{
    public class PlayersController : Controller
    {
        private ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var playersWithTeams = _context.Players.Include(p => p.Team).ToList();
            return View(playersWithTeams);
        }

        public ActionResult Details(int id)
        {
            var playerWithTeam = _context.Players.Include(p => p.Team).SingleOrDefault(p => p.Id == id);
            if(playerWithTeam == null)
            {
                return RedirectToAction("Index", "Players");
            }
            return View(playerWithTeam);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Player player = new Player();
            var teams = _context.Teams;
            var viewModel = new PlayerWithTeams()
            {
                Player = player,
                Teams = teams
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return RedirectToAction("Index", "Players");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var player = _context.Players.Find(id);
            var teams = _context.Teams;
            var viewModel = new PlayerWithTeams()
            {
                Player = player,
                Teams = teams
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            var playerInDB = _context.Players.Find(player.Id);
            if(playerInDB != null)
            {
                playerInDB.FirstName = player.FirstName;
                playerInDB.LastName = player.LastName;
                playerInDB.TeamId = player.TeamId;
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Players");
        }

        public ActionResult Delete(int id)
        {
            var player = _context.Players.SingleOrDefault(m => m.Id == id);
            _context.Players.Remove(player);
            _context.SaveChanges();
            var players = _context.Players.Include(m => m.Team).ToList();
            return View("Index", players);
        }

        // GET: Players/PlayersByTeam?teamId=5
        public ActionResult PlayersByTeam(int teamId)
        {
            var teamWithPlayers = _context.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == teamId);
            return View(teamWithPlayers);
        }
    }
}
