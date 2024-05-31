using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BpkbApi.Models;
using BpkbApi.Services;
using Microsoft.AspNetCore.Authorization;

namespace BpkbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrBpkbController : ControllerBase
    {
        private readonly ITrBpkbService _trBpkbService;

        public TrBpkbController(ITrBpkbService trBpkbService)
        {
            _trBpkbService = trBpkbService;
        }

        [HttpGet("GetTrBpkb")]
        public async Task<ActionResult<TrBpkb>> GetTrBpkb()
        {
            var trBpkb = await _trBpkbService.GetTrBpkb();
            if (trBpkb == null)
            {
                return NotFound();
            }

            return Ok(trBpkb);
        }

        [HttpPost("UpsertTrBpkb")]
        public async Task<ActionResult> UpsertTrBpkb([FromBody] RequestTrBpkb trBpkb)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var username = User.GetUserName();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            await _trBpkbService.UpsertTrBpkb(trBpkb, username);
            return Ok();
        }
    }
}
