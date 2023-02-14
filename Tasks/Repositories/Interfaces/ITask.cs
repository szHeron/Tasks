using Tasks.Models;

namespace Tasks.Repositories.Interfaces
{
    public interface ITask
    {
        Task<List<TaskModel>> SearchAllTasks();
        Task<TaskModel> SearchTaskById(Guid Id);
        Task<TaskModel> AddNewTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, Guid Id);
        Task<bool> DeleteTask(Guid Id);
    }
}
