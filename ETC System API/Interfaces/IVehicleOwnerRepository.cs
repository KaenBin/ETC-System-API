using ETC_System_API.Models;
using ETC_System_API.DTOs.VehicleOwner;
using ETC_System_API.Helpers;

namespace ETC_System_API.Interfaces
{
    public interface IVehicleOwnerRepository
    {
        Task<List<VehicleOwner>> GetAllAsync(QueryObject query);
        Task<VehicleOwner?> GetByIdAsync(int id);
        Task<VehicleOwner> CreateAsync(VehicleOwner vehicleOwnerModel);
        Task<VehicleOwner?> UpdateAsync(int id, CreateVehicleOwnerRequestDto vehicleOwnerDto);
        Task<VehicleOwner?> DeleteAsync(int id);
        Task<bool> OwnerExistsAsync(int id);
    }
}