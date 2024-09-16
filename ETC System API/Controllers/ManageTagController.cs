using ETC_System_API.Interfaces;
using ETC_System_API.Mappers;
using ETC_System_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageTagController : ControllerBase
    {
        public readonly IAdminRepository _adminRepo;
        public readonly ITollTagRepository _tollTagRepo;
        public readonly IManageTagRepository _manageTagRepo;
        public ManageTagController(IAdminRepository adminRepo, ITollTagRepository tollTagRepo, IManageTagRepository manageTagRepo)
        {
            _adminRepo = adminRepo;
            _tollTagRepo = tollTagRepo;
            _manageTagRepo = manageTagRepo;
        }

        [HttpGet("{adminId:int}")]
        public async Task<IActionResult> GetAll([FromRoute] int adminId)
        {
            var tollTags = await _manageTagRepo.GetByAdminIdAsync(adminId);
            return Ok(tollTags.Select(s => s.ToTollTagDto()));
        }

        [HttpPost("{adminId:int}/{tollTagId:int}")]
        public async Task<IActionResult> Create([FromRoute] int adminId, [FromRoute] int tollTagId)
        {
            var admin = await _adminRepo.GetByIdAsync(adminId);
            var tollTag = await _tollTagRepo.GetByIdAsync(tollTagId);

            if (admin == null || tollTag == null)
                return NotFound();

            var existingManageTags = await _manageTagRepo.GetByAdminIdAsync(adminId);
            if (existingManageTags.Exists(e => e.Id == tollTagId))
                return BadRequest("Cannot add same toll tag to the admin.");

            var manageTagModel = new ManageTag
            {
                AdminId = adminId,
                TollTagId = tollTagId
            };
            await _manageTagRepo.AddTag(manageTagModel);
            if (manageTagModel == null)
                return StatusCode(500, "Failed to add toll tag to the admin.");
            return Created();
        }

        [HttpDelete("{adminId:int}/{tollTagId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int adminId, [FromRoute] int tollTagId)
        {
            var admin = await _adminRepo.GetByIdAsync(adminId);
            var tollTag = await _tollTagRepo.GetByIdAsync(tollTagId);

            if (admin == null || tollTag == null)
                return NotFound();

            var manageTags = await _manageTagRepo.GetByAdminIdAsync(adminId);
            var manageTag = manageTags.Where(x => x.Id == tollTagId);

            if (manageTag == null)
                return NotFound();

            var manageTagModel = await _manageTagRepo.DeleteTag(admin, tollTag);
            if (manageTagModel == null)
                return BadRequest("Failed to delete toll tag from the admin.");
            return Ok();
        }
    }
}