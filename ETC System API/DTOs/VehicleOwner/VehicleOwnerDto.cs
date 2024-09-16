using ETC_System_API.DTOs.Vehicle;

namespace ETC_System_API.DTOs.VehicleOwner
{
    public class VehicleOwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public double? Balance { get; set; }
        public List<VehicleDto> Vehicles { get; set; } = [];
    }
}
