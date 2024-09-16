using ETC_System_API.Data;
using ETC_System_API.DTOs.TollStation;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class TollStationRepository : ITollStationRepository
    {
        private readonly ApplicationDBContext _context;
        public TollStationRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<TollStation> CreateAsync(TollStation tollStationModel)
        {
            await _context.TollStation.AddAsync(tollStationModel);
            await _context.SaveChangesAsync();
            return tollStationModel;
        }

        public async Task<TollStation?> DeleteAsync(int id)
        {
            var tollStationModel = await _context.TollStation.FirstOrDefaultAsync(x => x.Id == id);
            if (tollStationModel == null)
                return null;

            _context.Remove(tollStationModel);
            await _context.SaveChangesAsync();
            return tollStationModel;
        }

        public async Task<List<TollStation>> GetAllAsync()
        {
            return await _context.TollStation.Include(x => x.Devices).ToListAsync();
        }

        public async Task<TollStation?> GetByIdAsync(int id)
        {
            return await _context.TollStation.Include(x => x.Devices).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> TollStationExistsAsync(int tollStationId)
        {
            return _context.TollStation.AnyAsync(x => x.Id == tollStationId);
        }

        public async Task<TollStation?> UpdateAsync(int id, CreateTollStationRequestDto tollStationDto)
        {
            var existingTollStation = await _context.TollStation.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTollStation == null)
                return null;

            existingTollStation.Name = tollStationDto.Name;
            existingTollStation.Fee = tollStationDto.Fee;
            existingTollStation.Location = new NetTopologySuite.Geometries.Point(tollStationDto.Latitude, tollStationDto.Longitude) { SRID = 4326 };

            await _context.SaveChangesAsync();

            return existingTollStation;
        }
    }
}