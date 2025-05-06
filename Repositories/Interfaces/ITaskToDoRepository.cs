using TaskManagementAPI.Models.TaskToDo;

namespace TaskManagementAPI.Repositories.Interfaces
{
    public interface ITaskToDoRepository
    {
        Task<List<TaskToDo>> GetAllAsync(CancellationToken cancellationToken=default!);
        Task<TaskToDo> GetByIdAsync(int id, CancellationToken cancellationToken = default!);
        Task AddAsync(TaskToDo task, CancellationToken cancellationToken = default);
        Task<List<TaskToDo>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default!);
        void Update(TaskToDo task);
        void Delete(int id);
        void Detach(TaskToDo task);
    }
}
