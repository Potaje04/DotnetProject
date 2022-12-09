using Microsoft.AspNetCore.Mvc;
using MyprojectInC.Model.Claims.Repository;
using MyprojectInC.Model.Owner.Repository;
using MyprojectInC.Model.Owner;
using MyprojectInC.Model.Claims;

namespace MyprojectInC.Controllers
{
    [Route("claim/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;

        public ClaimController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }


        [HttpGet]
        public async Task<IActionResult> getAllClaims()
        {
            return Ok(await _claimRepository.GetAllClaims());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getClaimDetails(int id)
        {
            return Ok(await _claimRepository.GetClaimDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> createOwner([FromBody] Claim claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var owners = await _claimRepository.InsertClaim(claim);

            return Created("created", claim);
        }

        [HttpPut]
        public async Task<IActionResult> updateOwner([FromBody] Claim claim)
        {
            if (claim == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var owners = await _claimRepository.UpdateClaim(claim);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOwner(int id)
        {
            await _claimRepository.DeleteClaim(new Claim { Id = id});

            return NoContent();
        }
    }
}
