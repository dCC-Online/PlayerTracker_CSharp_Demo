using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerTracker.Data;
using PlayerTracker.Models;

namespace PlayerTracker.Controllers
{
    public class TeamsController : Controller
    {

        private ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teams
        public ActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        // GET: Teams/Details/5
        public ActionResult Details(int id)
        {
            var team = _context.Teams.Find(id);
            return View(team);
        }

        // GET: Teams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Teams/Edit/5
        public IActionResult Edit(int id)
        {
            // Retrieve the team by its Id from the database
            var team = _context.Teams.Find(id);

            if (team == null)
            {
                return NotFound();
            }

            return View(team); // Pass the team to the view for editing
        }


        // POST: Teams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Team team)
        {
            if (id != team.Id)
            {
                return NotFound(); // Handle the case when the team Id doesn't match
            }

            if (ModelState.IsValid)
            {
                // Update the team in the database
                _context.Update(team);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Redirect to the list of teams
            }

            // If there are validation errors or other issues, return to the edit form with the same team data
            return View(team);
        }

        // GET: Teams/Delete/5
        public ActionResult Delete(int id)
        {
            var team = _context.Teams.Find(id);
            _context.Teams.Remove(team);
            _context.SaveChanges();
            return View();
        }

    }
}
