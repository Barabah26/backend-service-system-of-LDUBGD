using Shared.Entities;

namespace statement_service.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        void Update(User user);
        void Delete(User user);
    }
}
