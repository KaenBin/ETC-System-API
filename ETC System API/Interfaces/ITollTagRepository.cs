using ETC_System_API.Models;
using ETC_System_API.DTOs.TollTag;

namespace ETC_System_API.Interfaces
{
    public interface ITollTagRepository
    {
        Task<List<TollTag>> GetAllAsync();
        Task<TollTag?> GetByIdAsync(int id);
        Task<TollTag> CreateAsync(TollTag tollTagModel);
        Task<TollTag?> UpdateAsync(int id, CreateTollTagRequestDto tollTagDto);
        Task<TollTag?> DeleteAsync(int id);
    }
}