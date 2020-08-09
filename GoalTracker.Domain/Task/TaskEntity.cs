using System;

namespace GoalTracker.Domain.Task
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public int Priority { get; set; }
        public string TaskStartTime { get; set; }
        public string TaskEndTime { get; set; }
    }
}
