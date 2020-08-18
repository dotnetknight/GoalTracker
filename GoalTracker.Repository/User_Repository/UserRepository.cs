using GoalTracker.Domain.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoalTracker.Repository.User_Repository
{
    public class UserRepository<T> : IUserRepository<T> where T : User
    {
        private readonly ApplicationContext context;
        private readonly DbSet<T> entities;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public Task<T> Get(string email)
        {
            return entities.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMyProfile()
        {
            await context.SaveChangesAsync();
        }
    }
}
