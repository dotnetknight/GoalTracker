using GoalTracker.Domain.Journal;
using GoalTracker.Models.Responses;
using GoalTracker.Services.Journal_Service;
using GoalTracker.Web.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace GoalTracker.Web.Handlers.CommandHandlers
{
    public class AddJournalCommandHandler : IRequestHandler<AddJournalCommand, AddJournalResponse>
    {
        private IJournalService _journalService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddJournalCommandHandler(IJournalService journalService, IHttpContextAccessor httpContextAccessor)
        {
            _journalService = journalService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AddJournalResponse> Handle(AddJournalCommand request, CancellationToken cancellationToken)
        {
            Journal journal = new Journal
            {
                Owner = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value,
                Text = request.Text,
                Title = request.Title,
                AddedDate = DateTime.Now
            };

            await _journalService.AddJournal(journal);

            return new AddJournalResponse
            {
                Message = "Journal has successfully added"
            };
        }
    }
}