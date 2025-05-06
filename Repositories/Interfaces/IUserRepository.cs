using TaskManagementAPI.Models.User;

namespace TaskManagementAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<DtoUser> GetAll();
        DtoUser GetById(int id);
        User GetByName(string name);
        void Add(DtoUser user);
        void Update(DtoUser user);
        void Delete(int id);
    }
}
