using GroupWebApp.Data;
using GroupWebApp.Interfaces;
using GroupWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            this.raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
           IEnumerable<Race> races = await raceRepository.GetAll();
            return View(races);
        }


        public async Task<IActionResult> Detail(int id)
        {
            Race race = await raceRepository.GetByIdAsync(id);
            return View(race);
        }
    }
}
