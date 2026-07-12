namespace task10.Models
{
    public class PaginationParams
    {
        private int _pageSize = 10;
        private int _page = 1;

        public int Page
        {
            get => _page;
            set => _page = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set
            {
                if (value < 1) _pageSize = 1;
                else if (value > 100) _pageSize = 100; // cap at 100
                else _pageSize = value;
            }
        }
    }
}
