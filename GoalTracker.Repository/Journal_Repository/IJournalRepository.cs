using GoalTracker.Domain.Journal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Repository.Journal_Repository
{
    public interface IJournalRepository<T> where T : Journal
    {
        Task<IEnumerable<Journal>> JournalsPerUser(string email);
        Task AddJournal(T entity);
    }
}
