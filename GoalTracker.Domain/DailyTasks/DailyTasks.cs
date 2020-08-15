namespace GoalTracker.Domain.DailyTasks
{
    public class DailyTasks : BaseEntity
    {
        public string Title { get; set; }
        public int Priority { get; set; }
        public string TaskStartTime { get; set; }
        public string TaskEndTime { get; set; }
        public string Owner { get; set; }
        public bool Done { get; set; }
    }
}
