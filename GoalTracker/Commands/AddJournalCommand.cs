using GoalTracker.Models.Responses;
using MediatR;

namespace GoalTracker.Web.Commands
{
    public class AddJournalCommand : IRequest<AddJournalResponse>
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}
