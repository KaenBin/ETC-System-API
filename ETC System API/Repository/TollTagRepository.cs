using ETC_System_API.Data;
using ETC_System_API.DTOs.TollTag;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class TollTagRepository : ITollTagRepository
    {
        private readonly ApplicationDBContext _context;
        public TollTagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TollTag> CreateAsync(TollTag tollTagModel)
        {
            await _context.TollTag.AddAsync(tollTagModel);
            await _context.SaveChangesAsync();
            return tollTagModel;
        }

        public async Task<TollTag?> DeleteAsync(int id)
        {
            var TollTagModel = await _context.TollTag.FirstOrDefaultAsync(x => x.Id == id);
            if (TollTagModel == null)
                return null;

            _context.Remove(TollTagModel);
            await _context.SaveChangesAsync();
            return TollTagModel;
        }

        public async Task<List<TollTag>> GetAllAsync()
        {
            return await _context.TollTag.ToListAsync();
        }

        public async Task<TollTag?> GetByIdAsync(int id)
        {
            return await _context.TollTag.FindAsync(id);
        }

        public async Task<TollTag?> UpdateAsync(int id, CreateTollTagRequestDto tollTagDto)
        {
            var existingTollTag = await _context.TollTag.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTollTag == null)
                return null;

            existingTollTag.ActivationDate = tollTagDto.ActivationDate;
            existingTollTag.ExpiredDate = tollTagDto.ExpiredDate;
            existingTollTag.Status = tollTagDto.Status;

            await _context.SaveChangesAsync();

            return existingTollTag;
        }
    }
}