using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Core.Interfaces
{
    public interface IOBL
    {
        Task<IEnumerable<OBL>> GetOBLsAsync();
    }
}
