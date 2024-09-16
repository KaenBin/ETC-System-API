using ETC_System_API.DTOs.ReaderDevice;
using ETC_System_API.DTOs.TollTag;

namespace ETC_System_API.DTOs.ReadTag
{
    public class ReadTagDto
    {
        public DateTime ReadTime { get; set; }
        public string? Status { get; set; } = string.Empty;
        public TollTagDto TollTag { get; set; }

    }
}
