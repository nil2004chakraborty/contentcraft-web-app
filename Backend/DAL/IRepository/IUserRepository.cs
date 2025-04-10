using Blog.DAL.Entity;

namespace Blog.DAL.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByIdAsync(int id);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> SoftDeleteUserAsync(int id);
    }
}
