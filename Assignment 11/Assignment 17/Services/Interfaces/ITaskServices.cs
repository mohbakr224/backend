using Assignment_17.DTOS;
using Assignment_17.Model;

namespace Assignment_17.Services.Interfaces
{
    public interface ITaskServices
    {
        void DeleteTask(int id);
        TaskModel CreateTask(TaskModelReqDTO task);
        IEnumerable<TaskModel> GetAllTasks();
    }
}
