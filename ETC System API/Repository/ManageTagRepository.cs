using ETC_System_API.Data;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class ManageTagRepository : IManageTagRepository
    {
        private readonly ApplicationDBContext _context;
        public ManageTagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ManageTag> AddTag(ManageTag newTag)
        {
            await _context.ManageTag.AddAsync(newTag);
            await _context.SaveChangesAsync();
            return newTag;
        }

        public async Task<ManageTag> DeleteTag(Admin admin, TollTag tollTag)
        {
            var manageTagModel = await _context.ManageTag.FirstOrDefaultAsync(x => x.AdminId == admin.Id && x.TollTagId == tollTag.Id);

            if (manageTagModel == null)
                return null;

            _context.ManageTag.Remove(manageTagModel);
            await _context.SaveChangesAsync();
            return manageTagModel;
        }

        public async Task<List<TollTag>> GetByAdminIdAsync(int adminId)
        {
            return await _context.ManageTag.Where(x => x.AdminId == adminId)
            .Select(tollTag => new TollTag
            {
                Id = tollTag.TollTagId,
                Status = tollTag.TollTag.Status,
                ActivationDate = tollTag.TollTag.ActivationDate,
                ExpiredDate = tollTag.TollTag.ExpiredDate,
            }).ToListAsync();
        }
    }
}