using System;

namespace GoalTracker.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
