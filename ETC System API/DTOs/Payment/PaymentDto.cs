using ETC_System_API.DTOs.ReaderDevice;
using ETC_System_API.DTOs.TollTag;
using ETC_System_API.Models;

namespace ETC_System_API.DTOs.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public string? Method { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = DateTime.Now;
        public required ReaderDeviceDto ReaderDevice { get; set; }
        public required TollTagDto TollTag { get; set; }
    }

}