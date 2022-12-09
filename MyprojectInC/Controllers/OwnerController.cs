using Microsoft.AspNetCore.Mvc;
using MyprojectInC.Model.Owner;
using MyprojectInC.Model.Owner.Repository;
using MyprojectInC.Model.Repositories;

namespace MyprojectInC.Controllers
{
    [Route("owner/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerRepository ownerRepository;

        public OwnerController(IOwnerRepository ownerRepository)
        {
            this.ownerRepository = ownerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAllOwners()
        {
            return Ok(await ownerRepository.GetAllOwners());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getOwnerDetails(int id)
        {
            return Ok(await ownerRepository.GetOwnerDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> createOwner([FromBody] Owner owner)
        {
            if(owner == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var owners = await ownerRepository.InsertOwner(owner);

            return Created("created", owners);
        }

        [HttpPut]
        public async Task<IActionResult> updateOwner([FromBody] Owner owner)
        {
            if (owner == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var owners = await ownerRepository.UpdateOwner(owner);

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteOwner(int id)
        {
            await ownerRepository.DeleteOwner(new Owner { Id = id});

            return NoContent();
        }
    }
}
