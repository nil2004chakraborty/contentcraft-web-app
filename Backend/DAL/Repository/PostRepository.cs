using Blog.DAL.DBContext;
using Blog.DAL.Entity;
using Blog.DAL.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Repository
{
    public class PostRepository : Repository<Post, BlogContext>, IPostRepository
    {
        private readonly BlogContext _context;
        public PostRepository(BlogContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _context.Posts.FindAsync(id);
        }

        public async Task<bool> UpdatePostAsync(Post post)
        {
            _context.Posts.Update(post);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> SoftDeletePostAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return false;
            }
            post.IsPublished = false;
            _context.Posts.Update(post);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
