using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalTracker.Domain.Task
{
    public class TaskMapper
    {
        public TaskMapper(EntityTypeBuilder<Task> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Priority).IsRequired();
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.TaskEndTime).IsRequired();
            entityBuilder.Property(t => t.TaskStartTime).IsRequired();
        }
    }
}