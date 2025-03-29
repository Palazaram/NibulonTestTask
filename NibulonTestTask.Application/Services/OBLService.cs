using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Application.Services
{
    public class OBLService
    {
        private readonly IOBL _obl;

        public OBLService(IOBL obl)
        {
            _obl = obl;
        }

        public async Task<IEnumerable<OBL>> GetOBLsAsync()
        {
            return await _obl.GetOBLsAsync();
        }
    }
}
