﻿using GoalTracker.Domain.Task;
using GoalTracker.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMapper(modelBuilder.Entity<User>());
            new TaskMapper(modelBuilder.Entity<Task>());
        }
    }
}
