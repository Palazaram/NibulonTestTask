using Microsoft.EntityFrameworkCore;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;
using NibulonTestTask.Persistence.Data;

namespace NibulonTestTask.Persistence.Repositories
{
    public class OBLRepository : IOBL
    {
        private readonly NibulonTestTaskDbContext _context;

        public OBLRepository(NibulonTestTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OBL>> GetOBLsAsync()
        {
            return await _context.OBLs.ToListAsync();
        }
    }
}
