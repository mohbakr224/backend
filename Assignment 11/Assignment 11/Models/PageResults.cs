using Assignment_11.Pagination;

namespace Assignment_11.Models
{
    public class PageResults<T>:PagingParams
    {
        public IEnumerable<T> Data {  get; set; }
        public int totalproducts { get; set; }
        public int totalpages=> (int)Math.Ceiling((double)totalproducts / PageSize);
        public bool hasprevious => Page > 1;
        public bool hasnext => Page < totalpages;

    }
}
