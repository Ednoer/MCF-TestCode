using BpkbApi.Models;

namespace BpkbApi.Services
{
    public interface IStorageLocationService
    {
        Task<IEnumerable<MsStorageLocation>> GetStorageLocations();
    }
}