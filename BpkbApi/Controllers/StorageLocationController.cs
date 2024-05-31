using BpkbApi.Models;
using BpkbApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BpkbApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MsStorageLocationController : ControllerBase
    {
        private readonly IStorageLocationService _service;

        public MsStorageLocationController(IStorageLocationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MsStorageLocation>>> GetStorageLocations()
        {
            var storageLocations = await _service.GetStorageLocations();
            return Ok(storageLocations);
        }
    }
}
