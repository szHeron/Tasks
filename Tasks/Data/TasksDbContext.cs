using Microsoft.EntityFrameworkCore;
using Tasks.Data.Map;
using Tasks.Models;

namespace Tasks.Data
{
    public class TasksDbContext : DbContext
    {
        public TasksDbContext(DbContextOptions<TasksDbContext> options)
            : base(options) 
        {

        }
    
        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
