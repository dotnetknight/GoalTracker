using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalTracker.Domain.Journal
{
    public class JournalMapper
    {
        public JournalMapper(EntityTypeBuilder<Journal> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Title).IsRequired();
        }
    }
}