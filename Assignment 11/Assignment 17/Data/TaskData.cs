using Assignment_17.Model;

namespace Assignment_17.Data
{
    public class TaskData
    {
        public List<TaskModel> Tasks { get; set; } = new List<TaskModel>
        {
            new TaskModel
            {
                Id = 1,
                Name = "Learn ASP.NET Core",
                ExpireDate = DateTime.Now.AddDays(5)
            },
            new TaskModel
            {
                Id = 2,
                Name = "Build Web API",
                ExpireDate = DateTime.Now.AddDays(10)
            },
            new TaskModel
            {
                Id = 3,
                Name = "Learn FluentValidation",
                ExpireDate = DateTime.Now.AddDays(3)
            },
            new TaskModel
            {
                Id = 4,
                Name = "Create Database",
                ExpireDate = DateTime.Now.AddDays(7)
            },
            new TaskModel
            {
                Id = 5,
                Name = "Implement Repository Pattern",
                ExpireDate = DateTime.Now.AddDays(12)
            },
            new TaskModel
            {
                Id = 6,
                Name = "Write Unit Tests",
                ExpireDate = DateTime.Now.AddDays(15)
            },
            new TaskModel
            {
                Id = 7,
                Name = "Add API Validation",
                ExpireDate = DateTime.Now.AddDays(6)
            },
            new TaskModel
            {
                Id = 8,
                Name = "Configure Swagger",
                ExpireDate = DateTime.Now.AddDays(4)
            },
            new TaskModel
            {
                Id = 9,
                Name = "Implement Exception Handling",
                ExpireDate = DateTime.Now.AddDays(8)
            },
            new TaskModel
            {
                Id = 10,
                Name = "Test API Endpoints",
                ExpireDate = DateTime.Now.AddDays(20)
            }
        };
    }
}