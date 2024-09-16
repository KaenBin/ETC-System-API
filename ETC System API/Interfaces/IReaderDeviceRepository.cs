using ETC_System_API.Models;
using ETC_System_API.DTOs.ReaderDevice;

namespace ETC_System_API.Interfaces
{
    public interface IReaderDeviceRepository
    {
        Task<List<ReaderDevice>> GetAllAsync();
        Task<ReaderDevice?> GetByIdAsync(int id);
        Task<ReaderDevice> CreateAsync(ReaderDevice readerDeviceModel);
        Task<ReaderDevice?> UpdateAsync(int id, CreateReaderDeviceRequestDto readerDeviceDto, TollStation? tollStation);
        Task<ReaderDevice?> DeleteAsync(int id);
    }
}