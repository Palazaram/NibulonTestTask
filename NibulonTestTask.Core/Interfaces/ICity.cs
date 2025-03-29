using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Core.Interfaces
{
    public interface ICity
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
