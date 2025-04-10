using Blog.DAL.Entity;

namespace Blog.DAL.IRepository
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> GetPostByIdAsync(int id);
        Task<bool> UpdatePostAsync(Post post);
        Task<bool> SoftDeletePostAsync(int id);
    }
}
