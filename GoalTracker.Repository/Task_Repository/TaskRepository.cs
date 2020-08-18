using GoalTracker.Domain.DailyTasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalTracker.Repository.Task_Repository
{
    public class TaskRepository<T> : ITaskRepository<T> where T : DailyTasks
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public TaskRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task<IEnumerable<DailyTasks>> DailyTasks(string email)
        {
            var dailyTasks = await DailyTasks();
            return dailyTasks.Where(t => t.Owner == email && t.AddedDate.ToShortDateString() == DateTime.Now.ToShortDateString());
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Task Entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateTaskDone()
        {
            await context.SaveChangesAsync();
        }

        public async Task<DailyTasks> TaskById(int taskId)
        {
            var dailyTasks = await DailyTasks();
            return dailyTasks.Where(h => h.Id == taskId).FirstOrDefault();
        }

        private async Task<IEnumerable<T>> DailyTasks()
        {
            return await entities.ToListAsync();
        }
    }
}