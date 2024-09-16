namespace ETC_System_API.DTOs.Payment
{
    public class UpdatePaymentRequestDto
    {
        public int Amount { get; set; }
        public string? Method { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = DateTime.Now;
    }

}