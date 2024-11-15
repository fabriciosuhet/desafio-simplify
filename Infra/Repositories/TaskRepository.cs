using DesafioSimplify.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSimplify.Infra.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
    { 
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskEntity?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task AddTaskAsync(TaskEntity? task)
    {
        await  _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTaskAsync(int id, TaskEntity task)
    {
        await _context.Tasks.FindAsync(id);
        _context.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}