using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunGroopWebApp.Data;
using RunGroopWebApp.Models;

namespace RunGroopWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Call DataBase
        public ClubController(ApplicationDbContext context) {
            _context = context;
        }

        public IActionResult Index()
        {
            
            List<Club> clubs = _context.Clubs.ToList();
            return View(clubs);
        }


        // Details = 1, single
        public IActionResult Detail(int id) { 
            Club club = _context.Clubs.Include(a => a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
    }
}
