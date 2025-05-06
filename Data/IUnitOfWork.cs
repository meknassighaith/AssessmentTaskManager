using TaskManagementAPI.Repositories.Interfaces;

namespace TaskManagementAPI.Data
{
    public interface IUnitOfWork  
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
        
    }
}
