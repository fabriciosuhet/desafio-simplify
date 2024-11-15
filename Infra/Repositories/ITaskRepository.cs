using DesafioSimplify.Entities;

namespace DesafioSimplify.Infra.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
    Task<TaskEntity?> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TaskEntity task);
    Task UpdateTaskAsync(int id, TaskEntity task);
    Task DeleteTaskAsync(int id);
}