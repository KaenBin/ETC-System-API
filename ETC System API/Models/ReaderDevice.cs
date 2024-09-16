using NetTopologySuite.Geometries;

namespace ETC_System_API.Models
{
    public class ReaderDevice
    {
        public int Id { get; set; }
        public Point? Location { get; set; }
        public string? RenderType { get; set; }
        public int? TollStationId { get; set; }
        public TollStation? TollStation { get; set; }
        public List<Payment> Payment { get; set; } = [];
        public List<ReadTag> ReadTag { get; set; } = [];
    }
}
