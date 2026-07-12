using System;

namespace task10.Models
{
    public class TaskFilterParams : PaginationParams
    {
        // Full-text-ish search across title/description
        public string? Search { get; set; }

        // nullable to allow not filtering by completion
        public bool? IsCompleted { get; set; }

        // sort field name
        public string? SortBy { get; set; }

        // descending order if true
        public bool SortDescending { get; set; }

        // Bonus: date range filters
        public DateTime? CreatedAfter { get; set; }
        public DateTime? CreatedBefore { get; set; }
    }
}
