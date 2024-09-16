using ETC_System_API.Models;
using ETC_System_API.DTOs.TollStation;

namespace ETC_System_API.Interfaces
{
    public interface ITollStationRepository
    {
        Task<List<TollStation>> GetAllAsync();
        Task<TollStation?> GetByIdAsync(int id);
        Task<TollStation> CreateAsync(TollStation tollStationModel);
        Task<TollStation?> UpdateAsync(int id, CreateTollStationRequestDto tollStationDto);
        Task<TollStation?> DeleteAsync(int id);
        Task<bool> TollStationExistsAsync(int tollStationId);
    }
}