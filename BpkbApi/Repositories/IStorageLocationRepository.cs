using System.Threading.Tasks;
using BpkbApi.Models;

namespace BpkbApi.Repositories
{
    public interface IStorageLocationRepository
    {
        Task<IEnumerable<MsStorageLocation>> GetStorageLocations();
    }
}
