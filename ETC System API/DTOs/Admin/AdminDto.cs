using ETC_System_API.DTOs.ManageTag;

namespace ETC_System_API.DTOs.Admin
{
    public class AdminDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
    }
}
