using ETC_System_API.Data;
using ETC_System_API.DTOs.ReaderDevice;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class ReaderDeviceRepository : IReaderDeviceRepository
    {
        private readonly ApplicationDBContext _context;
        public ReaderDeviceRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> ReaderDeviceExistsAsync(int id)
        {
            return _context.VehicleOwner.AnyAsync(o => o.Id == id);
        }

        public async Task<ReaderDevice> CreateAsync(ReaderDevice readerDeviceModel)
        {
            await _context.ReaderDevice.AddAsync(readerDeviceModel);
            await _context.SaveChangesAsync();
            return readerDeviceModel;
        }

        public async Task<ReaderDevice?> DeleteAsync(int id)
        {
            var readerDeviceModel = await _context.ReaderDevice.FirstOrDefaultAsync(x => x.Id == id);
            if (readerDeviceModel == null)
                return null;

            _context.Remove(readerDeviceModel);
            await _context.SaveChangesAsync();
            return readerDeviceModel;
        }

        public async Task<List<ReaderDevice>> GetAllAsync()
        {
            return await _context.ReaderDevice.Include(x => x.TollStation).ToListAsync();
        }

        public async Task<ReaderDevice?> GetByIdAsync(int id)
        {
            return await _context.ReaderDevice.Include(x => x.TollStation).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ReaderDevice?> UpdateAsync(int id, CreateReaderDeviceRequestDto readerDeviceDto, TollStation? tollStation)
        {
            var existingReaderDevice = await _context.ReaderDevice.FirstOrDefaultAsync(x => x.Id == id);
            if (existingReaderDevice == null)
                return null;

            existingReaderDevice.RenderType = readerDeviceDto.RenderType;
            existingReaderDevice.Location = new NetTopologySuite.Geometries.Point(readerDeviceDto.Longitude, readerDeviceDto.Latitude) { SRID = 4326 };
            existingReaderDevice.TollStation = tollStation;
            existingReaderDevice.TollStationId = tollStation?.Id;

            await _context.SaveChangesAsync();

            return existingReaderDevice;
        }
    }
}