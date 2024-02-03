using Microsoft.EntityFrameworkCore;
using ServiceCompanyTaskManager.Api.Models;
using ServiceCompanyTaskManager.Common.Models.Enums;

namespace ServiceCompanyTaskManager.Api.DbContexts
{
    public class ServiceCompanyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Desk> Desks { get; set; }

        public DbSet<ProjectTask> Tasks { get; set; }

        public ServiceCompanyDbContext(DbContextOptions<ServiceCompanyDbContext> options) : base(options)
        {
            Database.EnsureCreated();

            if (Users.Any(u => u.Permission == Permission.SuperAdmin) == false)
            {
                var admin = new User("A", "A", "SuperAdmin", "SuperAdmin", "SuperAdmin", Permission.SuperAdmin);
                Users.Add(admin);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<ProjectTask>()
                .HasOne(user => user.Author)
                .WithMany(task => task.UserCreatedTasks)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Entity<ProjectTask>()
                .HasOne(user => user.Executor)
                .WithMany(task => task.UserExecutedTasks)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
