using Assignment_17.DTOS;
using Assignment_17.Model;
using Assignment_17.Repository.interfaces;
using Assignment_17.Services.Interfaces;

namespace Assignment_17.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskrepo _taskrepo;

        public TaskServices(ITaskrepo taskrepo)
        {
            _taskrepo = taskrepo;
        }

        public TaskModel CreateTask(TaskModelReqDTO taskDto)
        {
            var task = new TaskModel
            {
                Name = taskDto.Name,
                ExpireDate = taskDto.ExpireDate
            };

            return _taskrepo.AddTask(task);
        }

        public void DeleteTask(int id)
        {
            _taskrepo.DeleteTask(id);
        }

        public IEnumerable<TaskModel> GetAllTasks()
        {
            return _taskrepo.GetTasks();
        }
    }
}