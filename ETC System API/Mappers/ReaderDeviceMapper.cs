using ETC_System_API.DTOs.ReaderDevice;
using ETC_System_API.Models;

namespace ETC_System_API.Mappers
{
    public static class ReaderDeviceMappers
    {
        public static ReaderDeviceDto ToReaderDeviceDto(this ReaderDevice readerDeviceModel)
        {
            return new ReaderDeviceDto
            {
                Id = readerDeviceModel.Id,
                Latitude = readerDeviceModel.Location?.Y,
                Longitude = readerDeviceModel.Location?.X,
                RenderType = readerDeviceModel.RenderType,
                TollStationName = readerDeviceModel.TollStation?.Name
            };
        }

        public static ReaderDevice ToReaderDeviceFromCreateDto(this CreateReaderDeviceRequestDto readerDeviceDTO, TollStation? tollStation)
        {
            return new ReaderDevice
            {
                RenderType = readerDeviceDTO.RenderType,
                Location = new NetTopologySuite.Geometries.Point(readerDeviceDTO.Longitude, readerDeviceDTO.Latitude) { SRID = 4326 },
                TollStation = tollStation,
                TollStationId = tollStation?.Id
            };
        }
    }
}