﻿using NibulonTestTask.Core.DTO;
using NibulonTestTask.Core.Models;

namespace NibulonTestTask.Core.Interfaces
{
    public interface IAUP
    {
        Task<IEnumerable<AUP>> GetAUPsAsync();
        AUP CreateAUPObject(PostalIndex postalIndex, IEnumerable<City> cities, IEnumerable<OBL> obls, IEnumerable<KRAJ> krajs);
        Task AddRangeAsync(IEnumerable<AUP> aups);
        Task TruncateAUPTableAsync();
    }
}
