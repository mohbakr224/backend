using Assignment_17.Data;
using Assignment_17.Model;
using Assignment_17.Repository.interfaces;

namespace Assignment_17.Repository
{
    public class Taskrepo : ITaskrepo
    {
        private readonly TaskData _taskData;

        public Taskrepo(TaskData taskData)
        {
            _taskData = taskData;
        }

        public TaskModel AddTask(TaskModel task)
        {
            task.Id = _taskData.Tasks.Any()
                ? _taskData.Tasks.Max(t => t.Id) + 1
                : 1;

            _taskData.Tasks.Add(task);

            return task;
        }

        public void DeleteTask(int id)
        {
            var task = _taskData.Tasks.FirstOrDefault(t => t.Id == id);

            _taskData.Tasks.Remove(task);
        }

        public IEnumerable<TaskModel> GetTasks()
        {
            return _taskData.Tasks;
        }

    }
}