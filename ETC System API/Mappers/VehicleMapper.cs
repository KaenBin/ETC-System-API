using ETC_System_API.DTOs.TollTag;
using ETC_System_API.DTOs.Vehicle;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class VehicleMappers
    {
        public static VehicleDto ToVehicleDto(this Vehicle vehicleModel)
        {
            return new VehicleDto
            {
                Id = vehicleModel.Id,
                VehicleType = vehicleModel.VehicleType,
                LicensePlateNumber = vehicleModel.LicensePlateNumber,
                VehicleOwnerId = vehicleModel.VehicleOwnerId,
                TollTag = vehicleModel.TollTag?.ToTollTagDto()
            };
        }
        public static Vehicle ToVehicleFromCreateDto(this CreateVehicleRequestDto vehicleDTO, int ownerId)
        {
            return new Vehicle
            {
                VehicleType = vehicleDTO.VehicleType,
                LicensePlateNumber = vehicleDTO.LicensePlateNumber,
                VehicleOwnerId = ownerId
            };
        }
        public static Vehicle ToVehicleFromUpdateDto(this UpdateVehicleRequestDto vehicleDTO, int ownerId)
        {
            return new Vehicle
            {
                VehicleType = vehicleDTO.VehicleType,
                LicensePlateNumber = vehicleDTO.LicensePlateNumber,
                VehicleOwnerId = ownerId,
            };
        }
    }
}