namespace ETC_System_API.Helpers
{
    public class QueryObject
    {
        public string? FilterBy { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsSortAscending { get; set; } = true;
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}