using Microsoft.EntityFrameworkCore;
using Tasks.Data;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Repositories
{
    public class TaskRepositorie : ITask
    {
        private readonly TasksDbContext _dbContext;
        public TaskRepositorie(TasksDbContext tasksDbContext)
        {
            _dbContext = tasksDbContext;
        }
        public async Task<List<TaskModel>> SearchAllTasks()
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<TaskModel> SearchTaskById(Guid Id)
        {
            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<TaskModel> AddNewTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<TaskModel> UpdateTask(TaskModel task, Guid Id)
        {
            TaskModel taskById = await SearchTaskById(Id);
            if (taskById == null)
            {
                throw new Exception($"Task ID: {Id} not found.");
            }
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.State = task.State;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;
        }

        public async Task<bool> DeleteTask(Guid Id)
        {
            TaskModel taskById = await SearchTaskById(Id);
            if (taskById == null)
            {
                throw new Exception($"Task ID: {Id} not found.");
            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}

