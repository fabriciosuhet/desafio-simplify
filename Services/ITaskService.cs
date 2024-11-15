using DesafioSimplify.Entities;

namespace DesafioSimplify.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TaskEntity task);
    Task UpdateTaskAsync(int id, TaskEntity task);
    Task DeleteTaskAsync(int id);
}