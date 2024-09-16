using ETC_System_API.Models;

namespace ETC_System_API.Interfaces
{
    public interface IManageTagRepository
    {
        public Task<List<TollTag>> GetByAdminIdAsync(int adminId);
        public Task<ManageTag> AddTag(ManageTag manageTag);
        // public Task<bool> UpdateTag(TollTag tollTag);
        public Task<ManageTag> DeleteTag(Admin admin, TollTag tollTag);
    }
}