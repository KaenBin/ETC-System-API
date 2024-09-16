using ETC_System_API.DTOs.Vehicle;

namespace ETC_System_API.DTOs.TollTag
{
    public class TollTagDto
    {
        public int Id { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Status { get; set; }
        public int VehicleId { get; set; }
        // public List<Payment> Payment { get; set; } = [];
    }
}
