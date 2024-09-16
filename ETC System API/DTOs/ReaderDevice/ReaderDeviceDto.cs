using ETC_System_API.Models;
using NetTopologySuite.Geometries;

namespace ETC_System_API.DTOs.ReaderDevice
{
    public class ReaderDeviceDto
    {
        public int Id { get; set; }
        public string? RenderType { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? TollStationName { get; set; }
        // public List<ReadTag> ReadTag { get; set; } = [];
    }

}