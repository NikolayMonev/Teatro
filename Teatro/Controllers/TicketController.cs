using Microsoft.AspNetCore.Mvc;
using Teatro.Data;
using Teatro.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Teatro.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TicketsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Tickets/Create
        public IActionResult Create(int playId)
        {
            var ticket = new Ticket { PlayId = playId };
            return View(ticket);
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayId,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.UserId = _userManager.GetUserId(User);
                ticket.PurchaseDate = System.DateTime.Now;

                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Plays");
            }
            return View(ticket);
        }
    }
}
