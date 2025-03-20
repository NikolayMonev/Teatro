using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Teatro.Models;
using Teatro.Data;
using System.Linq;

namespace Teatro.Controllers
{
    [Authorize]  // Това ограничава достъпа само до влезли потребители
    public class PlaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plays
        public IActionResult Index()
        {
            var plays = _context.Plays.ToList();
            return View(plays);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Play play)
        {
            if (ModelState.IsValid)
            {
                _context.Plays.Add(play);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(play);
        }
    }
}
