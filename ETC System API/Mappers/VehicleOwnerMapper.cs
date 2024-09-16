using ETC_System_API.DTOs.VehicleOwner;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class VehicleOwnerMappers
    {
        public static VehicleOwnerDto ToVehicleOwnerDto(this VehicleOwner vehicleOwnerModel)
        {
            return new VehicleOwnerDto
            {
                Id = vehicleOwnerModel.Id,
                FirstName = vehicleOwnerModel.FirstName,
                LastName = vehicleOwnerModel.LastName,
                ContactInfo = vehicleOwnerModel.ContactInfo,
                Balance = vehicleOwnerModel.Balance,
                Vehicles = vehicleOwnerModel.Vehicles.Select(s => s.ToVehicleDto()).ToList()
            };
        }

        public static VehicleOwner ToVehicleOwnerFromCreateDto(this CreateVehicleOwnerRequestDto vehicleOwnerDTO)
        {
            return new VehicleOwner
            {
                FirstName = vehicleOwnerDTO.FirstName,
                LastName = vehicleOwnerDTO.LastName,
                ContactInfo = vehicleOwnerDTO.ContactInfo,
                Balance = vehicleOwnerDTO.Balance
            };
        }
    }
}