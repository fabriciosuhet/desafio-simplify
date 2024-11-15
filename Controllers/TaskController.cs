using DesafioSimplify.Entities;
using DesafioSimplify.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioSimplify.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTask()
    {
        var tarefas = await _taskService.GetAllTasksAsync();
        return Ok(tarefas);
    }

    [HttpGet("{id}/tarefa")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var tarefa = await _taskService.GetTaskByIdAsync(id);
        return Ok(tarefa);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskEntity taskCreate)
    {
        
        await _taskService.AddTaskAsync(taskCreate);
        return CreatedAtAction(nameof(GetTaskById),new { id = taskCreate.Id }, taskCreate);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskEntity taskUpdate)
    {
        await _taskService.UpdateTaskAsync(id, taskUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _taskService.DeleteTaskAsync(id);
        return NoContent();
    }
}