using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;
using NibulonTestTask.Persistence.Data;

namespace NibulonTestTask.Persistence.Repositories
{
    public class KRAJRepository : IKRAJ
    {
        private readonly NibulonTestTaskDbContext _context;

        public KRAJRepository(NibulonTestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<KRAJ>> GetKRAJsAsync()
        {
            return await _context.KRAJs.ToListAsync();
        }
    }
}
