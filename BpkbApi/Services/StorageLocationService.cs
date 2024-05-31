using BpkbApi.Models;
using BpkbApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BpkbApi.Services
{
    public class MsStorageLocationService : IStorageLocationService
    {
        private readonly IStorageLocationRepository _repository;

        public MsStorageLocationService(IStorageLocationRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MsStorageLocation>> GetStorageLocations()
        {
            return await _repository.GetStorageLocations();
        }
    }
}
