using GroupWebApp.Data;
using GroupWebApp.Interfaces;
using GroupWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Repository
{
    public class RaceRepository :IRaceRepository
    {
        private readonly ApplicationDbContext context;

        public RaceRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Add(Race race)
        {
            context.Add(race);
            return Save();
        }

        public bool Delete(Race race)
        {
            context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAll()
        {
            return await context.Races.ToListAsync();
        }

        public async Task<IEnumerable<Race>> GetAllRacesByCIty(string city)
        {
            return await context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();
           
        }

        public async Task<Race> GetByIdAsync(int id)
        {
            return await context.Races.Include(i => i.Address).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Race race)
        {
            context.Update(race);
            return Save();
        }
    }
}
