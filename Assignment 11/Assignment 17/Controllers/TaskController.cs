using Assignment_17.DTOS;
using Assignment_17.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_17.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskServices.GetAllTasks();

            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskModelReqDTO task)
        {
            var createdTask = _taskServices.CreateTask(task);

            return CreatedAtAction(
                nameof(GetAllTasks),
                new { id = createdTask.Id },
                createdTask
            );
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            _taskServices.DeleteTask(id);
            return Created();
        }
    }
}