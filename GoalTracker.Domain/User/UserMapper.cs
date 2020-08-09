using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoalTracker.Domain.User
{
    public class UserMapper
    {
        public UserMapper(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Email).IsRequired();
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.Password).IsRequired();
        }
    }
}