namespace ETC_System_API.Models
{
    public class VehicleOwner
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public double? Balance { get; set; }
        public List<Vehicle> Vehicles { get; set; } = [];
    }
}
