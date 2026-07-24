namespace Assignment_11.Pagination
{
    public class PageFilter:PagingParams
    {
        public string? ProductName { get; set; }="";
        public bool? IsAvaliable { get; set; } = true;
        public bool? IsFavorite { get; set; } = false;
        public string sortby { get; set; }
    }
}
