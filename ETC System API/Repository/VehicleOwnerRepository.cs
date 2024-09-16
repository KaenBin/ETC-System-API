using ETC_System_API.Data;
using ETC_System_API.DTOs.VehicleOwner;
using ETC_System_API.Helpers;
using ETC_System_API.Interfaces;
using ETC_System_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ETC_System_API.Repository
{
    public class VehicleOwnerRepository : IVehicleOwnerRepository
    {
        private readonly ApplicationDBContext _context;
        public VehicleOwnerRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<VehicleOwner> CreateAsync(VehicleOwner vehicleOwnerModel)
        {
            await _context.VehicleOwner.AddAsync(vehicleOwnerModel);
            await _context.SaveChangesAsync();
            return vehicleOwnerModel;
        }

        public async Task<VehicleOwner?> DeleteAsync(int id)
        {
            var vehicleOwnerModel = await _context.VehicleOwner.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleOwnerModel == null)
                return null;

            _context.Remove(vehicleOwnerModel);
            await _context.SaveChangesAsync();
            return vehicleOwnerModel;
        }

        public async Task<List<VehicleOwner>> GetAllAsync(QueryObject query)
        {
            var owners = _context.VehicleOwner.Include(x => x.Vehicles).ThenInclude(x => x.TollTag).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query?.FilterBy))
                owners = owners.Where(x => x.FirstName.Contains(query.FilterBy) || x.LastName.Contains(query.FilterBy) || x.ContactInfo.Contains(query.FilterBy) || x.Balance.ToString().Contains(query.FilterBy));

            if (!string.IsNullOrWhiteSpace(query?.SortBy))
                switch (query.SortBy)
                {
                    case "firstname":
                        owners = query.IsSortAscending ? owners.OrderBy(x => x.FirstName) : owners.OrderByDescending(x => x.FirstName);
                        break;
                    case "lastname":
                        owners = query.IsSortAscending ? owners.OrderBy(x => x.LastName) : owners.OrderByDescending(x => x.LastName); ;
                        break;
                    case "contactinfo":
                        owners = query.IsSortAscending ? owners.OrderBy(x => x.ContactInfo) : owners.OrderByDescending(x => x.ContactInfo); ;
                        break;
                    case "balance":
                        owners = query.IsSortAscending ? owners.OrderBy(x => x.Balance) : owners.OrderByDescending(x => x.Balance);
                        break;
                }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await owners.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<VehicleOwner?> GetByIdAsync(int id)
        {
            return await _context.VehicleOwner.Include(x => x.Vehicles).ThenInclude(x => x.TollTag).FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<bool> OwnerExistsAsync(int id)
        {
            return _context.VehicleOwner.AnyAsync(o => o.Id == id);
        }

        public async Task<VehicleOwner?> UpdateAsync(int id, CreateVehicleOwnerRequestDto vehicleOwnerDto)
        {
            var existingVehicleOwner = await _context.VehicleOwner.FirstOrDefaultAsync(x => x.Id == id);
            if (existingVehicleOwner == null)
                return null;

            existingVehicleOwner.FirstName = vehicleOwnerDto.FirstName;
            existingVehicleOwner.LastName = vehicleOwnerDto.LastName;
            existingVehicleOwner.ContactInfo = vehicleOwnerDto.ContactInfo;
            existingVehicleOwner.Balance = vehicleOwnerDto.Balance;

            await _context.SaveChangesAsync();

            return existingVehicleOwner;
        }
    }
}