
using ETC_System_API.Data;
using Microsoft.AspNetCore.Mvc;
using ETC_System_API.Mappers;
using ETC_System_API.DTOs.Admin;
using ETC_System_API.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ETC_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepo;
        public AdminController(IAdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var admins = await _adminRepo.GetAllAsync();

            return Ok(admins.Select(s => s.ToAdminDto()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var admin = await _adminRepo.GetByIdAsync(id);

            if (admin == null)
                return NotFound();

            return Ok(admin.ToAdminDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminRequestDto adminDto)
        {
            var adminModel = adminDto.ToAdminFromCreateDto();
            await _adminRepo.CreateAsync(adminModel);
            return CreatedAtAction(nameof(GetById), new { id = adminModel.Id }, adminModel.ToAdminDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, CreateAdminRequestDto adminDto)
        {
            var adminModel = await _adminRepo.UpdateAsync(id, adminDto);

            if (adminModel == null)
                return NotFound();

            return Ok(adminModel.ToAdminDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var adminModel = await _adminRepo.DeleteAsync(id);

            if (adminModel == null)
                return NotFound();

            return NoContent();
        }
    }
}
