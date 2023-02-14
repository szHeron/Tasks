using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITask _taskRepositorie;
        public TaskController(ITask taskRepositorie)
        {
            _taskRepositorie = taskRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllUsers()
        {
            List<TaskModel> tasks = await _taskRepositorie.SearchAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskModel>>> GetById(Guid id)
        {
            TaskModel task = await _taskRepositorie.SearchTaskById(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskModel>>> CreateNewTask([FromBody] TaskModel newTask)
        {
            TaskModel task = await _taskRepositorie.AddNewTask(newTask);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<TaskModel>>> UpdateTaskById(Guid id, [FromBody] TaskModel newTask)
        {
            TaskModel task = await _taskRepositorie.UpdateTask(newTask, id);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskModel>>> DeleteTaskById(Guid id)
        {
            bool response = await _taskRepositorie.DeleteTask(id);
            return Ok(response);
        }
    }
}
