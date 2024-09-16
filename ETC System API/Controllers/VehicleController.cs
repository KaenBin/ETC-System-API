using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.DTOs.Vehicle;
using ETC_System_API.Interfaces;
using ETC_System_API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepo; private readonly IVehicleOwnerRepository _vehicleOwnerRepo;

        public VehicleController(IVehicleRepository vehicleRepo, IVehicleOwnerRepository vehicleOwnerRepo)
        {
            _vehicleRepo = vehicleRepo;
            _vehicleOwnerRepo = vehicleOwnerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var vehicles = await _vehicleRepo.GetAllAsync(query);

            return Ok(vehicles.Select(s => s.ToVehicleDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicle = await _vehicleRepo.GetByIdAsync(id);

            if (vehicle == null)
                return NotFound();

            return Ok(vehicle.ToVehicleDto());
        }
        [HttpGet("owner/{ownerId:int}")]
        public async Task<IActionResult> GetByOwnerId([FromRoute] int ownerId, [FromQuery] VehicleQueryObject query)
        {
            var vehicles = await _vehicleRepo.GetByOwnerIdAsync(ownerId, query);
            return Ok(vehicles.Select(s => s.ToVehicleDto()));
        }
        [HttpPost("{ownerId:int}")]
        public async Task<IActionResult> Create([FromRoute] int ownerId, CreateVehicleRequestDto vehicleDto)
        {
            if (!await _vehicleOwnerRepo.OwnerExistsAsync(ownerId))
                return BadRequest("Owner does not exist!");

            var vehicleModel = vehicleDto.ToVehicleFromCreateDto(ownerId);
            await _vehicleRepo.CreateAsync(vehicleModel);
            return CreatedAtAction(nameof(GetById), new { id = vehicleModel.Id }, vehicleModel.ToVehicleDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateVehicleRequestDto vehicleDto)
        {
            var vehicleModel = await _vehicleRepo.UpdateAsync(id, vehicleDto);

            if (vehicleModel == null)
                return NotFound();

            return Ok(vehicleModel.ToVehicleDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicleModel = await _vehicleRepo.DeleteAsync(id);

            if (vehicleModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
