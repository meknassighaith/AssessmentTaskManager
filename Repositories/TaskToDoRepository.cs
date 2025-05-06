using Microsoft.EntityFrameworkCore;
using System;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models.TaskToDo;
using TaskManagementAPI.Repositories.Interfaces;

namespace TaskManagementAPI.Repositories
{
    public class TaskToDoRepository(TaskManagementDB context): ITaskToDoRepository
    {
        private readonly TaskManagementDB _context = context;
        public async Task<List<TaskToDo>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Tasks.ToListAsync(cancellationToken);
        }

        public async Task<TaskToDo> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            
            var taskToDo = await _context.Tasks.FindAsync(id, cancellationToken);
            return taskToDo ?? throw new ArgumentException("Task not found", nameof(id));
        }

        public async Task<List<TaskToDo>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            var res =await _context.Tasks.Where(t => t.AssignedUserId == userId).ToListAsync(cancellationToken);
            return res;
        }
      
         
        public async Task AddAsync(TaskToDo task, CancellationToken cancellationToken = default)
        {
             await _context.Tasks.AddAsync(task,cancellationToken); 
        }

        public void Update(TaskToDo task) { _context.Tasks.Update(task); }

        public void Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null) _context.Tasks.Remove(task);
        }
        public void Detach(TaskToDo task)
        {
            _context.Entry(task).State = EntityState.Detached;
        }


    }
}
