using System.Collections.Generic;
using System.Threading.Tasks;
using task10.Models;

namespace task10.Services
{
    public interface ITaskService
    {
        Task<PagedResult<TaskItem>> GetAllAsync(TaskFilterParams filter);
    }
}
