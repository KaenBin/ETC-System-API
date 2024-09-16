namespace ETC_System_API.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public List<ManageTag> ManageTag { get; set; } = [];
    }
}
