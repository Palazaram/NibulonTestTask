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

        public AUP CreateAUPObject(PostalIndex postalIndex, IEnumerable<City> cities)
        {
            var city = cities.FirstOrDefault(c =>
                c.CITY == postalIndex.City &&
                (c.Obl?.NOBL == postalIndex.Region || c.OBL_KOD is null) &&
                (c.Kraj?.NRAJ == postalIndex.District || c.KRAJ_KOD is null)
            );

            var aup = new AUP 
            {
                INDEX_A = postalIndex.Index,
                CITY_KOD = city is not null ? city.CITY_KOD : null,
                OBL_KOD = city is not null ? city.Obl?.KOBL : null,
                RAJ_KOD = city is not null ? city.Kraj?.KRAJ_ID : null
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
