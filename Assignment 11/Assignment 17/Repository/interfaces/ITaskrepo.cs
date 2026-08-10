using Assignment_17.Model;

namespace Assignment_17.Repository.interfaces
{
    public interface ITaskrepo
    {
        TaskModel AddTask(TaskModel taskModel);
        void DeleteTask(int id);
        IEnumerable<TaskModel> GetTasks();
    }
}
