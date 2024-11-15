using DesafioSimplify.Entities;
using DesafioSimplify.Infra.Repositories;

namespace DesafioSimplify.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }
    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    {
        return await _taskRepository.GetAllTasksAsync();
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(int id)
    {
        var tarefaExistente = await _taskRepository.GetTaskByIdAsync(id);
        if (tarefaExistente == null)
        {
            throw new Exception("Tarefa não encontrada");
        }
        return tarefaExistente;
    }

    public async Task AddTaskAsync(TaskEntity task)
    {
        if (task.Name == null || task.Description == null)
        {
            throw new ArgumentNullException("O nome da tarefa ou a descrição não pode ser nula");
        }
        await _taskRepository.AddTaskAsync(task);
    }

    public async Task UpdateTaskAsync(int id, TaskEntity updateTask)
    {
        var tarefaExistente = await _taskRepository.GetTaskByIdAsync(id);
        if (tarefaExistente?.Id == null)
        {
            throw new Exception("Tarefa não encontrada");
        }
        
        tarefaExistente.UpdateName(updateTask.Name);
        tarefaExistente.UpdateDescription(updateTask.Description);
        tarefaExistente.UpdatePriority(updateTask.Priority);
        if (updateTask.Completed && !tarefaExistente.Completed)
        {
            tarefaExistente.MarkAsCompleted();
        }

        await _taskRepository.UpdateTaskAsync(id, tarefaExistente);
    }

    public async Task DeleteTaskAsync(int id)
    {
        var tarefaExistente = await _taskRepository.GetTaskByIdAsync(id);
        if (tarefaExistente == null)
        {
            throw new Exception("A tarefa não foi encontrada");
        }
        await _taskRepository.DeleteTaskAsync(id);
    }
}