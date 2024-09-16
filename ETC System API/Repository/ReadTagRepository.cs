using ETC_System_API.Data;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class ReadTagRepository : IReadTagRepository
    {
        private readonly ApplicationDBContext _context;
        public ReadTagRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ReadTag> AddTag(ReadTag newTag)
        {
            await _context.ReadTag.AddAsync(newTag);
            await _context.SaveChangesAsync();
            return newTag;
        }

        public async Task<ReadTag> DeleteTag(ReaderDevice readerDevice, TollTag tollTag)
        {
            var readTagModel = await _context.ReadTag.FirstOrDefaultAsync(x => x.ReaderDeviceId == readerDevice.Id && x.TollTagId == tollTag.Id);

            if (readTagModel == null)
                return null;

            _context.ReadTag.Remove(readTagModel);
            await _context.SaveChangesAsync();
            return readTagModel;
        }

        public async Task<List<ReadTag>> GetByReaderDeviceIdAsync(int readerDeviceId)
        {
            return await _context.ReadTag
                .Where(x => x.ReaderDeviceId == readerDeviceId)
                .Include(x => x.TollTag)
                .Include(x => x.ReaderDevice)
                .ToListAsync();
        }
    }
}