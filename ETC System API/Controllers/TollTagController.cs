using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.Interfaces;
using ETC_System_API.DTOs.TollTag;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollTagController : ControllerBase
    {
        private readonly ITollTagRepository _tollTagRepo;
        private readonly IVehicleRepository _vehicleRepo;
        public TollTagController(ITollTagRepository tollTagRepo, IVehicleRepository vehicleRepo)
        {
            _tollTagRepo = tollTagRepo;
            _vehicleRepo = vehicleRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tollTags = await _tollTagRepo.GetAllAsync();

            return Ok(tollTags.Select(s => s.ToTollTagDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tollTag = await _tollTagRepo.GetByIdAsync(id);

            if (tollTag == null)
                return NotFound();

            return Ok(tollTag.ToTollTagDto());
        }

        [HttpPost("{vehicleId:int}")]
        public async Task<IActionResult> Create([FromRoute] int vehicleId, CreateTollTagRequestDto tollTagDto)
        {
            if (!await _vehicleRepo.VehicleExistsAsync(vehicleId))
                return BadRequest("Vehicle does not exist!");

            var tollTagModel = tollTagDto.ToTollTagFromCreateDto(vehicleId);
            await _tollTagRepo.CreateAsync(tollTagModel);
            return CreatedAtAction(nameof(GetById), new { id = tollTagModel.Id }, tollTagModel.ToTollTagDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateTollTagRequestDto tollTagDto)
        {
            var tollTagModel = await _tollTagRepo.UpdateAsync(id, tollTagDto);

            if (tollTagModel == null)
                return NotFound();

            return Ok(tollTagModel.ToTollTagDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tollTagModel = await _tollTagRepo.DeleteAsync(id);

            if (tollTagModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
