namespace ETC_System_API.Helpers
{
    public class VehicleQueryObject
    {
        public DateTime? ActivatedDateFrom { get; set; } = null;
        public DateTime? ActivatedDateTo { get; set; } = null;
        public DateTime? ExpiredDateFrom { get; set; } = null;
        public DateTime? ExpiredDateTo { get; set; } = null;
    }
}