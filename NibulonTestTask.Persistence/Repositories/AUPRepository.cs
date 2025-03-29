using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Core.DTO;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;
using NibulonTestTask.Persistence.Data;

namespace NibulonTestTask.Persistence.Repositories
{
    public class AUPRepository : IAUP
    {
        private readonly NibulonTestTaskDbContext _context;

        public AUPRepository(NibulonTestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AUP>> GetAUPsAsync()
        {
            return await _context.AUPs.ToListAsync();
        }

        public AUP CreateAUPObject(PostalIndex postalIndex, IEnumerable<City> cities, IEnumerable<OBL> obls, IEnumerable<KRAJ> krajs)
        {
            var city = cities.FirstOrDefault(c => c.CITY == postalIndex.City);
            var obl = obls.FirstOrDefault(o => o.NOBL == postalIndex.Region);
            var kraj = krajs.FirstOrDefault(k => k.NRAJ == postalIndex.District);

            var aup = new AUP 
            {
                INDEX_A = postalIndex.Index,
                CITY_KOD = city is not null ? city.CITY_KOD : null,
                OBL_KOD = obl is not null ? obl.KOBL : null,
                RAJ_KOD = kraj is not null ? kraj.KRAJ_ID : null
            };

            return aup;
        }

        public async Task AddRangeAsync(IEnumerable<AUP> aups)
        {
            await _context.AddRangeAsync(aups);
            await _context.SaveChangesAsync();
        }

        public async Task TruncateAUPTableAsync()
        {
            await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE AUPs");
            _context.ChangeTracker.Clear();
        }
    }
}
