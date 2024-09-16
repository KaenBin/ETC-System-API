
using ETC_System_API.DTOs.ReaderDevice;
using NetTopologySuite.Geometries;

namespace ETC_System_API.DTOs.TollStation
{
    public class CreateTollStationRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int Fee { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
