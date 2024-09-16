using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.Interfaces;
using ETC_System_API.DTOs.TollStation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollStationController : ControllerBase
    {
        private readonly ITollStationRepository _tollStationRepo;
        private readonly IAdminRepository _adminRepo;
        public TollStationController(ITollStationRepository tollStationRepo, IAdminRepository adminRepo)
        {
            _tollStationRepo = tollStationRepo;
            _adminRepo = adminRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tollStations = await _tollStationRepo.GetAllAsync();

            return Ok(tollStations.Select(s => s.ToTollStationDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tollStation = await _tollStationRepo.GetByIdAsync(id);

            if (tollStation == null)
                return NotFound();

            return Ok(tollStation.ToTollStationDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTollStationRequestDto tollStationDto)
        {
            var tollStationModel = tollStationDto.ToTollStationFromCreateDto();
            await _tollStationRepo.CreateAsync(tollStationModel);
            return CreatedAtAction(nameof(GetById), new { id = tollStationModel.Id }, tollStationModel.ToTollStationDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateTollStationRequestDto tollStationDto)
        {
            var tollStationModel = await _tollStationRepo.UpdateAsync(id, tollStationDto);

            if (tollStationModel == null)
                return NotFound();

            return Ok(tollStationModel.ToTollStationDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var tollStationModel = await _tollStationRepo.DeleteAsync(id);

            if (tollStationModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
