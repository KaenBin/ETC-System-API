namespace ETC_System_API.DTOs.Payment
{
    public class CreatePaymentRequestDto
    {
        public int Amount { get; set; }
        public string? Method { get; set; }
        public DateTime? Date { get; set; } = DateTime.Now;
    }

}