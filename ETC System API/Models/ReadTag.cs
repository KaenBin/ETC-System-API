namespace ETC_System_API.Models
{
    public class ReadTag
    {
        public int ReaderDeviceId { get; set; }
        public int TollTagId { get; set; }
        public ReaderDevice ReaderDevice { get; set; }
        public TollTag TollTag { get; set; }
        public DateTime ReadTime { get; set; }
        public string? Status { get; set; } = string.Empty;
    }
}