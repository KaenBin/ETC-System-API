using ETC_System_API.DTOs.TollTag;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class TollTagMappers
    {
        public static TollTagDto ToTollTagDto(this TollTag tollTagModel)
        {
            return new TollTagDto
            {
                Id = tollTagModel.Id,
                ActivationDate = tollTagModel.ActivationDate,
                ExpiredDate = tollTagModel.ExpiredDate,
                Status = tollTagModel.Status,
                VehicleId = tollTagModel.VehicleId
            };
        }

        public static TollTag ToTollTagFromCreateDto(this CreateTollTagRequestDto tollTagDTO, int vehicleId)
        {
            return new TollTag
            {
                ActivationDate = tollTagDTO.ActivationDate,
                ExpiredDate = tollTagDTO.ExpiredDate,
                Status = tollTagDTO.Status,
                VehicleId = vehicleId
            };
        }
    }
}