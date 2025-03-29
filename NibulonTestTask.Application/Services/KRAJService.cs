using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Application.Services
{
    public class KRAJService
    {
        private readonly IKRAJ _kraj;

        public KRAJService(IKRAJ kraj)
        {
            _kraj = kraj;
        }

        public async Task<IEnumerable<KRAJ>> GetKRAJsAsync()
        {
            return await _kraj.GetKRAJsAsync();
        }
    }
}
