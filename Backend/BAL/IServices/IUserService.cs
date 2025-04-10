using Blog.DAL.Entity;
using Blog.Helper;
using Blog.Models;

namespace Blog.BAL.IServices
{
    public interface IUserService
    {
        Task<int> CreateUser(UserModel um);
        public ServiceResponse<User> UpdateUser(int id, UserModel userModel);
        public ServiceResponse<User> DeleteUser(int id);
    }
}
