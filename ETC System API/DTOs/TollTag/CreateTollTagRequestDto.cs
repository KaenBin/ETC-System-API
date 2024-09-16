
namespace ETC_System_API.DTOs.TollTag
{
    public class CreateTollTagRequestDto
    {
        public DateTime? ActivationDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string? Status { get; set; }
    }
}
