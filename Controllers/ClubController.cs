using GroupWebApp.Data;
using GroupWebApp.Interfaces;
using GroupWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository clubRepository;

        public ClubController(IClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await clubRepository.GetAll(); ;
            return View(clubs);
        }

        public async Task<IActionResult> Detail(int id) 
        {
            Club club = await clubRepository.GetByIdAsync(id);
            return View(club);
        }
    }

}
