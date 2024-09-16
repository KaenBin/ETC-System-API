
using ETC_System_API.DTOs.TollTag;

namespace ETC_System_API.DTOs.Vehicle
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string? VehicleType { get; set; }
        public string? LicensePlateNumber { get; set; }
        public int VehicleOwnerId { get; set; }
        public TollTagDto? TollTag { get; set; }
    }
}
