using ETC_System_API.Data;
using ETC_System_API.DTOs.Admin;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDBContext _context;
        public AdminRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> AdminExistsAsync(int id)
        {
            return _context.VehicleOwner.AnyAsync(o => o.Id == id);
        }

        public async Task<Admin> CreateAsync(Admin adminModel)
        {
            await _context.Admin.AddAsync(adminModel);
            await _context.SaveChangesAsync();
            return adminModel;
        }

        public async Task<Admin?> DeleteAsync(int id)
        {
            var adminModel = await _context.Admin.FirstOrDefaultAsync(x => x.Id == id);
            if (adminModel == null)
                return null;

            _context.Remove(adminModel);
            await _context.SaveChangesAsync();
            return adminModel;
        }

        public async Task<List<Admin>> GetAllAsync()
        {
            return await _context.Admin.ToListAsync();
        }

        public async Task<Admin?> GetByIdAsync(int id)
        {
            return await _context.Admin.FindAsync(id);
        }

        public async Task<Admin?> UpdateAsync(int id, CreateAdminRequestDto adminDto)
        {
            var existingAdmin = await _context.Admin.FirstOrDefaultAsync(x => x.Id == id);
            if (existingAdmin == null)
                return null;

            existingAdmin.FirstName = adminDto.FirstName;
            existingAdmin.LastName = adminDto.LastName;
            existingAdmin.ContactInfo = adminDto.ContactInfo;

            await _context.SaveChangesAsync();

            return existingAdmin;
        }
    }
}