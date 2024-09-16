using ETC_System_API.Models;

namespace ETC_System_API.Interfaces
{
    public interface IReadTagRepository
    {
        public Task<List<ReadTag>> GetByReaderDeviceIdAsync(int readerDeviceId);
        public Task<ReadTag> AddTag(ReadTag readTag);
        // public Task<bool> UpdateTag(TollTag tollTag);
        public Task<ReadTag> DeleteTag(ReaderDevice readerDevice, TollTag tollTag);
    }
}