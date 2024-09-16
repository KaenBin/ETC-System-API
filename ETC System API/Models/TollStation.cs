
using NetTopologySuite.Geometries;

namespace ETC_System_API.Models
{
    public class TollStation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Fee { get; set; }
        public Point Location { get; set; }
        public List<ReaderDevice> Devices { get; set; } = [];
    }
}
