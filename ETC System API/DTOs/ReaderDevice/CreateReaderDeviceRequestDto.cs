using ETC_System_API.Models;
using NetTopologySuite.Geometries;

namespace ETC_System_API.DTOs.ReaderDevice
{
    public class CreateReaderDeviceRequestDto
    {
        public string? RenderType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

}