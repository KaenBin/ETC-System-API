using ETC_System_API.Interfaces;
using ETC_System_API.Mappers;
using ETC_System_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadTagController : ControllerBase
    {
        public readonly IReaderDeviceRepository _readerDeviceRepo;
        public readonly ITollTagRepository _tollTagRepo;
        public readonly IReadTagRepository _readTagRepo;
        public ReadTagController(IReaderDeviceRepository readerDeviceRepo, ITollTagRepository tollTagRepo, IReadTagRepository readTagRepo)
        {
            _readerDeviceRepo = readerDeviceRepo;
            _tollTagRepo = tollTagRepo;
            _readTagRepo = readTagRepo;
        }

        [HttpGet("{readerDeviceId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int readerDeviceId)
        {
            var readTags = await _readTagRepo.GetByReaderDeviceIdAsync(readerDeviceId);
            return Ok(readTags.Select(s => s.ToReadTagDto()));
        }

        [HttpPost("{readerDeviceId:int}/{tollTagId:int}")]
        public async Task<IActionResult> Create([FromRoute] int readerDeviceId, [FromRoute] int tollTagId)
        {
            var readerDevice = await _readerDeviceRepo.GetByIdAsync(readerDeviceId);
            var tollTag = await _tollTagRepo.GetByIdAsync(tollTagId);

            if (readerDevice == null || tollTag == null)
                return NotFound();

            var readTagModel = new ReadTag
            {
                ReaderDeviceId = readerDeviceId,
                TollTagId = tollTagId
            };
            await _readTagRepo.AddTag(readTagModel);
            if (readTagModel == null)
                return StatusCode(500, "Failed to add toll tag to the admin.");
            return Created();
        }

        [HttpDelete("{readerDeviceId:int}/{tollTagId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int readerDeviceId, [FromRoute] int tollTagId)
        {
            var readerDevice = await _readerDeviceRepo.GetByIdAsync(readerDeviceId);
            var tollTag = await _tollTagRepo.GetByIdAsync(tollTagId);

            if (readerDevice == null || tollTag == null)
                return NotFound();

            var readTags = await _readTagRepo.GetByReaderDeviceIdAsync(readerDeviceId);
            var readTag = readTags.Where(x => x.TollTagId == tollTagId);

            if (readTag == null)
                return NotFound();

            var readTagModel = await _readTagRepo.DeleteTag(readerDevice, tollTag);
            if (readTagModel == null)
                return BadRequest("Failed to delete toll tag from the admin.");
            return Ok();
        }
    }
}