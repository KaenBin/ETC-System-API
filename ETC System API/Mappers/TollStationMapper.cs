using ETC_System_API.DTOs.TollStation;
using ETC_System_API.Models;
using NetTopologySuite.Geometries;

namespace ETC_System_API.Mappers
{
    public static class TollStationMappers
    {
        public static TollStationDto ToTollStationDto(this TollStation tollStationModel)
        {
            return new TollStationDto
            {
                Id = tollStationModel.Id,
                Name = tollStationModel.Name,
                Fee = tollStationModel.Fee,
                Location = tollStationModel.Location,
                Devices = tollStationModel.Devices.Select(x => x.ToReaderDeviceDto()).ToList()
            };
        }

        public static TollStation ToTollStationFromCreateDto(this CreateTollStationRequestDto tollStationDTO)
        {
            return new TollStation
            {
                Name = tollStationDTO.Name,
                Fee = tollStationDTO.Fee,
                Location = new Point(tollStationDTO.Latitude, tollStationDTO.Longitude) { SRID = 4326 },
            };
        }
    }
}