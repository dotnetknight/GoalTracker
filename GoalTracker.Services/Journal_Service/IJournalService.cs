using GoalTracker.Domain.Journal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoalTracker.Services.Journal_Service
{
    public interface IJournalService
    {
        Task AddJournal(Journal journal);
        Task<IEnumerable<Journal>> JournalPerUser(string email);
    }
}
