namespace ETC_System_API.DTOs.Admin
{
    public class CreateAdminRequestDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
    }
}
