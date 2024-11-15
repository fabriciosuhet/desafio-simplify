using DesafioSimplify.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioSimplify.Infra;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options){}
    
    public DbSet<TaskEntity> Tasks { get; set; }
}