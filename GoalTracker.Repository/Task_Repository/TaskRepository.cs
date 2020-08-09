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
        private DbSet<T> entities;

        public TaskRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DailyTasks>> DailyTasksByEmail(string email)
        {
            var res = await entities.ToListAsync();
            return res.Where(h => h.Owner == email);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Task Entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
