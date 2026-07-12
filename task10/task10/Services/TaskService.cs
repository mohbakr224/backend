using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task10.Models;

namespace task10.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _items;

        // whitelist of allowable sort fields -> key selector
        private static readonly Dictionary<string, Func<TaskItem, object>> SortSelectors =
            new(StringComparer.OrdinalIgnoreCase)
            {
                ["title"] = t => t.Title,
                ["createdat"] = t => t.CreatedAt,
                ["iscompleted"] = t => t.IsCompleted,
                ["id"] = t => t.Id
            };

        public TaskService()
        {
            // seed some sample data
            _items = new List<TaskItem>
            {
                new TaskItem { Title = "Buy groceries", Description = "Milk, Bread, Eggs", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-5) },
                new TaskItem { Title = "Meeting with team", Description = "Discuss Q3 goals", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-10) },
                new TaskItem { Title = "Write report", Description = "Monthly financials", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-2) },
                new TaskItem { Title = "Call supplier", Description = "Order parts", IsCompleted = false, CreatedAt = DateTime.UtcNow.AddDays(-1) },
                new TaskItem { Title = "Team meeting follow-up", Description = "Send notes", IsCompleted = true, CreatedAt = DateTime.UtcNow.AddDays(-3) }
            };
        }

        public Task<PagedResult<TaskItem>> GetAllAsync(TaskFilterParams filter)
        {
            if (filter == null) filter = new TaskFilterParams();

            // start with all items
            IEnumerable<TaskItem> query = _items.AsEnumerable();

            // apply search
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                var s = filter.Search.Trim();
                query = query.Where(t => (t.Title != null && t.Title.Contains(s, StringComparison.OrdinalIgnoreCase))
                                          || (t.Description != null && t.Description.Contains(s, StringComparison.OrdinalIgnoreCase)));
            }

            // apply completion filter
            if (filter.IsCompleted.HasValue)
            {
                query = query.Where(t => t.IsCompleted == filter.IsCompleted.Value);
            }

            // apply date range filters (bonus)
            if (filter.CreatedAfter.HasValue)
            {
                query = query.Where(t => t.CreatedAt >= filter.CreatedAfter.Value);
            }
            if (filter.CreatedBefore.HasValue)
            {
                query = query.Where(t => t.CreatedAt <= filter.CreatedBefore.Value);
            }

            // determine total count before pagination
            var totalCount = query.Count();

            // sorting: choose selector from whitelist; default to createdAt
            Func<TaskItem, object> selector;
            if (string.IsNullOrWhiteSpace(filter.SortBy) || !SortSelectors.TryGetValue(filter.SortBy.Trim(), out selector))
            {
                // fallback default
                selector = SortSelectors["createdat"];
            }

            query = filter.SortDescending ? query.OrderByDescending(selector) : query.OrderBy(selector);

            // pagination: ensure Page and PageSize already normalized by PaginationParams
            var page = Math.Max(1, filter.Page);
            var pageSize = Math.Min(100, Math.Max(1, filter.PageSize));

            var skip = (page - 1) * pageSize;
            var itemsOnPage = query.Skip(skip).Take(pageSize).ToList();

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var result = new PagedResult<TaskItem>
            {
                Items = itemsOnPage,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                HasNextPage = page < totalPages,
                HasPreviousPage = page > 1
            };

            return System.Threading.Tasks.Task.FromResult(result);
        }
    }
}
