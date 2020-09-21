using GoalTracker.Domain.Journal;
using GoalTracker.Repository.Journal_Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoalTracker.Services.Journal_Service
{
    public class JournalService : IJournalService
    {
        private readonly IJournalRepository<Journal> _journalRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JournalService(IJournalRepository<Journal> journalRepository, IHttpContextAccessor httpContextAccessor)
        {
            _journalRepository = journalRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task AddJournal(Journal journal)
        {
            await _journalRepository.AddJournal(journal);
        }

        public async Task<IEnumerable<Journal>> JournalPerUser(string email)
        {
            return await _journalRepository.JournalsPerUser(email);
        }
    }
}