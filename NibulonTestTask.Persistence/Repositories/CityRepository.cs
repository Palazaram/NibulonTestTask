using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;
using NibulonTestTask.Persistence.Data;

namespace NibulonTestTask.Persistence.Repositories
{
    public class CityRepository : ICity
    {
        private readonly NibulonTestTaskDbContext _context;

        public CityRepository(NibulonTestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
