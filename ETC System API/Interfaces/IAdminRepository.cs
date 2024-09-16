using ETC_System_API.Models;
using ETC_System_API.DTOs.Admin;

namespace ETC_System_API.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAsync();
        Task<Admin?> GetByIdAsync(int id);
        Task<Admin> CreateAsync(Admin adminModel);
        Task<Admin?> UpdateAsync(int id, CreateAdminRequestDto adminDto);
        Task<Admin?> DeleteAsync(int id);
        Task<bool> AdminExistsAsync(int id);
    }
}