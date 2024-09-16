using ETC_System_API.Models;
using ETC_System_API.DTOs.Vehicle;
using ETC_System_API.Helpers;

namespace ETC_System_API.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<Vehicle>> GetAllAsync(QueryObject query);
        Task<Vehicle?> GetByIdAsync(int id);
        Task<List<Vehicle>?> GetByOwnerIdAsync(int ownerId, VehicleQueryObject query);
        Task<Vehicle> CreateAsync(Vehicle vehicleModel);
        Task<Vehicle?> UpdateAsync(int id, UpdateVehicleRequestDto vehicleDto);
        Task<Vehicle?> DeleteAsync(int id);
        Task<bool> VehicleExistsAsync(int id);
    }
}