namespace ETC_System_API.Models
{
    public class ManageTag
    {
        public int TollTagId { get; set; }
        public int AdminId { get; set; }

        public TollTag TollTag { get; set; }
        public Admin Admin { get; set; }
        public string AccessLevel { get; set; } = string.Empty;
    }
}