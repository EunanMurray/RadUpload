using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2022ClassLibrary.Models;
using _2022PracticePaper.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2022MVC.Controllers
{
    [Authorize(Roles = "Registrar")]
    public class TeamsController : Controller
    {
        private readonly DbContext2022 _context;

        public TeamsController(DbContext2022 context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var team = await _context.Teams
                .Include(t => t.Players)
                .FirstOrDefaultAsync(m => m.TeamID == id);

            return team == null ? NotFound() : View(team);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TeamID,TeamName")] Teams team)
        {
            if (ModelState.IsValid)
            {
                _context.Add(team);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var team = await _context.Teams.FindAsync(id);
            return team == null ? NotFound() : View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TeamID,TeamName")] Teams team)
        {
            if (id != team.TeamID) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(team);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamExists(team.TeamID)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(team);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.TeamID == id);

            return team == null ? NotFound() : View(team);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var team = await _context.Teams.FindAsync(id);
            if (team != null)
            {
                _context.Teams.Remove(team);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ViewTeam(int? teamId)
        {
            ViewBag.Teams = new SelectList(await _context.Teams.ToListAsync(), "TeamID", "TeamName");

            if (!teamId.HasValue)
                return View();

            var players = await _context.Players
                .Where(p => p.TeamID == teamId)
                .ToListAsync();

            return View((object)players);
        }

        [HttpGet]
        public async Task<IActionResult> _PlayersList(int teamId)
        {
            var players = await _context.Players
                .Where(p => p.TeamID == teamId)
                .ToListAsync();

            return PartialView(players);
        }

        private bool TeamExists(int id)
        {
            return _context.Teams.Any(e => e.TeamID == id);
        }
    }
}