using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalTracker.Domain.DailyTasks
{
    public class DailyTasksMapper
    {
        public DailyTasksMapper(EntityTypeBuilder<DailyTasks> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Priority).IsRequired();
            entityBuilder.Property(t => t.Title).IsRequired();
            entityBuilder.Property(t => t.TaskEndTime).IsRequired();
            entityBuilder.Property(t => t.TaskStartTime).IsRequired();
            entityBuilder.Property(t => t.Owner).IsRequired();
        }
    }
}