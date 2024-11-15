using DesafioSimplify.Enums;

namespace DesafioSimplify.Entities;

public class TaskEntity
{
    public int Id { get; }
    public string? Name { get;  set; }
    public string? Description { get;  set; }
    public bool Completed { get;  set; }
    public PriorityEnum Priority { get;  set; }

    public TaskEntity(){}
    
    public TaskEntity(string? name, string? description, bool completed, PriorityEnum priority)
    {
        Name = name;
        Description = description;
        Completed = completed;
        Priority = priority;
    }

    public void UpdateName(string? nameUpdate)
    {
        Name = nameUpdate;
    }

    public void UpdateDescription(string? descriptionUpdate)
    {
        Description = descriptionUpdate;
    }

    public void UpdatePriority(PriorityEnum priorityUpdate)
    {
        Priority = priorityUpdate;
    }
    
    public void MarkAsCompleted()
    {
        if (!Completed)
        {
            Completed = true;
        }
    }
}