using NibulonTestTask.Core.DTO;
using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Application.Services
{
    public class AUPService
    {
        private readonly IAUP _aup;

        public AUPService(IAUP aup)
        {
            _aup = aup;
        }

        public async Task<IEnumerable<AUP>> GetAUPsAsync()
        {
            return await _aup.GetAUPsAsync();
        }

        public AUP CreateAUPObject(PostalIndex postalIndex, IEnumerable<City> cities)
        {
            return _aup.CreateAUPObject(postalIndex, cities);
        }

        public async Task AddRangeAsync(IEnumerable<AUP> aups)
        {
            await _aup.AddRangeAsync(aups);
        }

        public async Task TruncateAUPTableAsync()
        {
            await _aup.TruncateAUPTableAsync();
        }
    }
}
