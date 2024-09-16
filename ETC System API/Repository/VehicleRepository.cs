using ETC_System_API.Data;
using ETC_System_API.DTOs.Vehicle;
using ETC_System_API.Helpers;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Vehicle> CreateAsync(Vehicle vehicleModel)
        {
            await _context.Vehicle.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();
            return vehicleModel;
        }

        public async Task<Vehicle?> DeleteAsync(int id)
        {
            var VehicleModel = await _context.Vehicle.FirstOrDefaultAsync(x => x.Id == id);
            if (VehicleModel == null)
                return null;

            _context.Remove(VehicleModel);
            await _context.SaveChangesAsync();
            return VehicleModel;
        }

        public async Task<List<Vehicle>> GetAllAsync(QueryObject query)
        {
            var vehicles = _context.Vehicle.Include(x => x.TollTag).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query?.FilterBy))
                vehicles = vehicles.Where(x => x.VehicleType.Contains(query.FilterBy) || x.LicensePlateNumber.Contains(query.FilterBy) || x.VehicleOwnerId.ToString().Contains(query.FilterBy) || x.TollTag.Id.ToString().Contains(query.FilterBy));

            if (!string.IsNullOrWhiteSpace(query?.SortBy))
                switch (query.SortBy)
                {
                    case "licenseplatenumber":
                        vehicles = query.IsSortAscending ? vehicles.OrderBy(x => x.LicensePlateNumber) : vehicles.OrderByDescending(x => x.LicensePlateNumber);
                        break;
                    case "vehicletype":
                        vehicles = query.IsSortAscending ? vehicles.OrderBy(x => x.VehicleType) : vehicles.OrderByDescending(x => x.VehicleType);
                        break;
                    case "vehicleownerid":
                        vehicles = query.IsSortAscending ? vehicles.OrderBy(x => x.VehicleOwnerId) : vehicles.OrderByDescending(x => x.VehicleOwnerId); ;
                        break;
                    case "tolltag":
                        vehicles = query.IsSortAscending ? vehicles.OrderBy(x => x.TollTag) : vehicles.OrderByDescending(x => x.TollTag);
                        break;
                }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await vehicles.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context.Vehicle.Include(x => x.TollTag).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<List<Vehicle>?> GetByOwnerIdAsync(int ownerId, VehicleQueryObject query)
        {
            var vehicles = await _context.Vehicle.Include(x => x.TollTag).Where(x => x.VehicleOwnerId == ownerId).AsQueryable().ToListAsync();

            if (vehicles == null)
                return null;

            if (query.ActivatedDateFrom != null)
                vehicles = vehicles.Where(x => x.TollTag?.ActivationDate >= query.ActivatedDateFrom).ToList();
            if (query.ActivatedDateTo != null)
                vehicles = vehicles.Where(x => x.TollTag?.ActivationDate <= query.ActivatedDateTo).ToList();
            if (query.ExpiredDateFrom != null)
                vehicles = vehicles.Where(x => x.TollTag?.ExpiredDate >= query.ExpiredDateFrom).ToList();
            if (query.ExpiredDateTo != null)
                vehicles = vehicles.Where(x => x.TollTag?.ExpiredDate <= query.ExpiredDateTo).ToList();

            return vehicles;
        }
        public async Task<Vehicle?> UpdateAsync(int id, UpdateVehicleRequestDto vehicleDto)
        {
            var existingVehicle = await _context.Vehicle.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVehicle == null)
                return null;

            existingVehicle.VehicleType = vehicleDto.VehicleType;
            existingVehicle.LicensePlateNumber = vehicleDto.LicensePlateNumber;

            await _context.SaveChangesAsync();

            return existingVehicle;
        }

        public Task<bool> VehicleExistsAsync(int id)
        {
            return _context.Vehicle.AnyAsync(o => o.Id == id);
        }
    }
}