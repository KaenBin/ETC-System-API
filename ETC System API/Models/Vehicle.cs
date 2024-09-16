namespace ETC_System_API.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? VehicleType { get; set; }
        public string? LicensePlateNumber { get; set; }
        public int VehicleOwnerId { get; set; }
        public TollTag? TollTag { get; set; }
    }
}
