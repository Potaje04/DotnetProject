using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyprojectInC.Model.Repositories;
using MyprojectInC.Model.Vehicles;

namespace MyprojectInC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVehicles()
        {
            return Ok(await vehicleRepository.GetAllVehicles());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicleDetails(int id)
        {
            return Ok(await vehicleRepository.GetVehicleDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> createVehicle([FromBody] Vehicle vehicle)
        {
            if(vehicle == null)
                return BadRequest();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicles = await vehicleRepository.InsertVehicle(vehicle);

            return Created("created", vehicles);
        }

        [HttpPut]
        public async Task<IActionResult> updateVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicles = await  vehicleRepository.UpdateVehicle(vehicle);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            await vehicleRepository.DeleteVehicle(new Vehicle { Id = id });

            return NoContent();
        }
    }
}
