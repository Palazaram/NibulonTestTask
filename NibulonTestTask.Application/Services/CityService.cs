using NibulonTestTask.Core.Interfaces;
using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Application.Services
{
    public class CityService
    {
        private readonly ICity _city;

        public CityService(ICity city)
        {
            _city = city;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _city.GetCitiesAsync();
        }
    }
}
