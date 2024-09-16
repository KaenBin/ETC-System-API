
using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.DTOs.VehicleOwner;
using ETC_System_API.Interfaces;
using ETC_System_API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOwnerController : ControllerBase
    {
        private readonly IVehicleOwnerRepository _vehicleOwnerRepo;
        public VehicleOwnerController(IVehicleOwnerRepository vehicleOwnerRepo)
        {
            _vehicleOwnerRepo = vehicleOwnerRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var vehicleOwners = await _vehicleOwnerRepo.GetAllAsync(query);

            return Ok(vehicleOwners.Select(s => s.ToVehicleOwnerDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var vehicleOwner = await _vehicleOwnerRepo.GetByIdAsync(id);

            if (vehicleOwner == null)
                return NotFound();

            return Ok(vehicleOwner.ToVehicleOwnerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVehicleOwnerRequestDto vehicleOwnerDto)
        {
            var vehicleOwnerModel = vehicleOwnerDto.ToVehicleOwnerFromCreateDto();
            await _vehicleOwnerRepo.CreateAsync(vehicleOwnerModel);
            return CreatedAtAction(nameof(GetById), new { id = vehicleOwnerModel.Id }, vehicleOwnerModel.ToVehicleOwnerDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateVehicleOwnerRequestDto vehicleOwnerDto)
        {
            var vehicleOwnerModel = await _vehicleOwnerRepo.UpdateAsync(id, vehicleOwnerDto);

            if (vehicleOwnerModel == null)
                return NotFound();

            return Ok(vehicleOwnerModel.ToVehicleOwnerDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var vehicleOwnerModel = await _vehicleOwnerRepo.DeleteAsync(id);

            if (vehicleOwnerModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
