using GoalTracker.Domain.DailyTasks;
using GoalTracker.Domain.Journal;
using GoalTracker.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMapper(modelBuilder.Entity<User>());
            new DailyTasksMapper(modelBuilder.Entity<DailyTasks>());
            new JournalMapper(modelBuilder.Entity<Journal>());
        }
    }
}
