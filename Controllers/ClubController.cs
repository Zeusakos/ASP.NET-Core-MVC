using GroupWebApp.Data;
using GroupWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly ApplicationDbContext context;

        public ClubController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            List<Club> clubs= context.Clubs.ToList();
            return View(clubs);
        }

        public IActionResult Detail(int id) 
        {
            Club club = context.Clubs.Include(a=>a.Address).FirstOrDefault(c => c.Id == id);
            return View(club);
        }
    }

}
