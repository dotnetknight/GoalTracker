using GoalTracker.Domain.Journal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalTracker.Repository.Journal_Repository
{
    public class JournalRepository<T> : IJournalRepository<T> where T : Journal
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public JournalRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task AddJournal(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Journal>> JournalsPerUser(string email)
        {
            var dailyTasks = await entities.ToListAsync();
            return dailyTasks.Where(t => t.Owner == email);
        }
    }
}
