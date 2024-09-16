namespace ETC_System_API.DTOs.VehicleOwner
{
    public class CreateVehicleOwnerRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public double? Balance { get; set; }
    }
}
