
using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.DTOs.ReaderDevice;
using ETC_System_API.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderDeviceController : ControllerBase
    {
        private readonly IReaderDeviceRepository _readerDeviceRepo;
        private readonly ITollStationRepository _tollStationRepo;
        public ReaderDeviceController(IReaderDeviceRepository readerDeviceRepo, ITollStationRepository tollStationRepo)
        {
            _readerDeviceRepo = readerDeviceRepo;
            _tollStationRepo = tollStationRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var readerDevices = await _readerDeviceRepo.GetAllAsync();

            return Ok(readerDevices.Select(s => s.ToReaderDeviceDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var readerDevice = await _readerDeviceRepo.GetByIdAsync(id);

            if (readerDevice == null)
                return NotFound();

            return Ok(readerDevice.ToReaderDeviceDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReaderDeviceRequestDto readerDeviceDto, [FromQuery] int tollStationId = -1)
        {
            var tollStation = await _tollStationRepo.GetByIdAsync(tollStationId);

            if (tollStation == null && tollStationId != -1)
                return BadRequest("Toll station does not exist!");

            var readerDeviceModel = readerDeviceDto.ToReaderDeviceFromCreateDto(tollStation);
            await _readerDeviceRepo.CreateAsync(readerDeviceModel);
            return CreatedAtAction(nameof(GetById), new { id = readerDeviceModel.Id }, readerDeviceModel.ToReaderDeviceDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateReaderDeviceRequestDto readerDeviceDto, [FromQuery] int tollStationId = -1)
        {
            var tollStation = await _tollStationRepo.GetByIdAsync(tollStationId);

            if (tollStation == null && tollStationId != -1)
                return BadRequest("Toll station does not exist!");

            var readerDeviceModel = await _readerDeviceRepo.UpdateAsync(id, readerDeviceDto, tollStation);

            if (readerDeviceModel == null)
                return NotFound();

            return Ok(readerDeviceModel.ToReaderDeviceDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var readerDeviceModel = await _readerDeviceRepo.DeleteAsync(id);

            if (readerDeviceModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
