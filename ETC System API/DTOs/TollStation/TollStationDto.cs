using ETC_System_API.DTOs.ReaderDevice;
using NetTopologySuite.Geometries;

namespace ETC_System_API.DTOs.TollStation
{
    public class TollStationDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Fee { get; set; }
        public Point Location { get; set; }
        public List<ReaderDeviceDto> Devices { get; set; } = [];
    }
}
