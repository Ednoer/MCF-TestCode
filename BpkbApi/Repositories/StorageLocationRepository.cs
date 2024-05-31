using BpkbApi.Data;
using BpkbApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BpkbApi.Repositories
{
    public class MsStorageLocationRepository : IStorageLocationRepository
    {
        private readonly BpkbContext _context;

        public MsStorageLocationRepository(BpkbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MsStorageLocation>> GetStorageLocations()
        {
            return await _context.MsStorageLocations.ToListAsync();
        }
    }
}
