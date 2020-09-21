namespace GoalTracker.Domain.Journal
{
    public class Journal : BaseEntity
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Owner { get; set; }
    }
}
