using Blog.DAL.DBContext;
using Blog.DAL.Entity;
using Blog.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Repository
{
    public class UserRepository : Repository<User, BlogContext>, IUserRepository
    {
        private readonly BlogContext _Context;
        public UserRepository(BlogContext context) : base(context)
        {
            _Context = context;
        }
        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _Context.Users.FindAsync(id);
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            _Context.Users.Update(user);
            return await _Context.SaveChangesAsync() > 0;
        }
        public async Task<bool> SoftDeleteUserAsync(int id)
        {
            var user = await _Context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            user.IsActive = false;
            _Context.Users.Update(user);
            return await _Context.SaveChangesAsync() > 0;
        }
    }
}
