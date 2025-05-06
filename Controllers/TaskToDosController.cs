using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.CompilerServices;
using System.Threading;
using TaskManagementAPI.Models.TaskToDo;
using TaskManagementAPI.Repositories.Interfaces;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskToDosController : ControllerBase
    {
        private readonly TaskToDoService _taskToDoService;
        private readonly ILogger<TaskToDosController> _logger;

        public TaskToDosController(TaskToDoService taskToDoService, ILogger<TaskToDosController> logger)
        {
            _taskToDoService = taskToDoService;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Get all tasks")]
        public IActionResult GetAllTasks(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting all tasks");
            return Ok(_taskToDoService.GetAll(cancellationToken));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,User")]
        [SwaggerOperation(Summary = "Get task by ID")]
        public IActionResult GetById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Getting task by ID: {Id}", id);
            var task = _taskToDoService.GetByIdAsync(id, cancellationToken);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }//=> 
            //Ok(_taskToDoService.GetByIdAsync(id,cancellationToken));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Create a new task")]
        public async Task<IActionResult> Create(TaskToDo taskToDo, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Creating task: {Task}", taskToDo);
            await _taskToDoService.Add(taskToDo, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = taskToDo.Id }, taskToDo);
        }

        [HttpPut("UpdateTask")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Update an existing task")]
        public async Task<IActionResult> Update(TaskToDo taskToDo, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating task: {Task}", taskToDo);
            await _taskToDoService.Update(taskToDo, cancellationToken);
            return NoContent();
        }

        [HttpPut("UpdateStatusTask/{id}")]
        [Authorize(Roles = "Admin,User")]
        [SwaggerOperation(Summary = "Update task status")]
        public async Task<IActionResult> UpdateTaskStatus(int id, TStatus newTaskStatus, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Updating task status: {Id}", id);
            await _taskToDoService.UpdateTaskStatus(id, newTaskStatus, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Delete a task")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting task by ID: {Id}", id);    
            await _taskToDoService.Delete(id, cancellationToken);
            return NoContent();
        }
    }
}