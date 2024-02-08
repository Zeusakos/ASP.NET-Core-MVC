using GroupWebApp.Data;
using GroupWebApp.Interfaces;
using GroupWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GroupWebApp.Repository
{
    public class ClubRepository : IClubRepository
    {
        private readonly ApplicationDbContext context;

        public ClubRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Add(Club club)
        {
            context.Add(club);
            return Save();
        }

        public bool Delete(Club club)
        {
            context.Remove(club);
            return Save();
        }

        public async Task<IEnumerable<Club>> GetAll()
        {
            return await context.Clubs.ToListAsync();
        }

        public async Task<Club> GetByIdAsync(int id)
        {
            return await context.Clubs.Include(i=> i.Address).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Club>> GetCLubByCIty(string city)
        {
           return await context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();
        }

        public bool Save()
        {
            var saved = context.SaveChanges();
            return saved > 0 ? true : false;

        }

        public bool Update(Club club)
        {
           context.Update(club);
            return Save();
        }
    }
}
