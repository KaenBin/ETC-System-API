namespace ETC_System_API.Models
{
    public class TollTag
    {
        public int Id { get; set; }
        public DateTime? ActivationDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Status { get; set; }
        public Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }
        public List<Payment> Payment { get; set; } = [];
        public List<ManageTag> ManageTag { get; set; } = [];
        public List<ReadTag> ReadTag { get; set; } = [];
    }
}
