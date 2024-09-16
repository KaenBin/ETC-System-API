namespace ETC_System_API.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? Method { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = DateTime.Now;
        public int ReaderDeviceId { get; set; }
        public ReaderDevice ReaderDevice { get; set; }
        public int TollTagId { get; set; }
        public TollTag TollTag { get; set; }
    }
}
