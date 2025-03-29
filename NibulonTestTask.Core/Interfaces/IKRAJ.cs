using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Core.Interfaces
{
    public interface IKRAJ
    {
        Task<IEnumerable<KRAJ>> GetKRAJsAsync();
    }
}
