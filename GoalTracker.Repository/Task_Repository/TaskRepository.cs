using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Task = System.Threading.Tasks.Task;

namespace GoalTracker.Repository.Task_Repository
{
    public class TaskRepository<T> : ITaskRepository<T> where T : Domain.Task.Task
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
