using Microsoft.AspNetCore.Mvc;
using task10.Models;
using task10.Services;

namespace task10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<PagedResult<TaskItem>>> GetAll([FromQuery] TaskFilterParams filter)
        {
            var result = await _taskService.GetAllAsync(filter ?? new TaskFilterParams());
            return Ok(result);
        }
    }
}
