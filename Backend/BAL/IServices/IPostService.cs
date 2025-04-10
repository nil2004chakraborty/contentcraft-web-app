using Blog.DAL.Entity;
using Blog.Helper;
using Blog.Models;

namespace Blog.BAL.IServices
{
    public interface IPostService
    {
        Task<int> CreatePost(PostModel pm);
        public ServiceResponse<Post> UpdatePost(int id, PostModel postModel);
        public ServiceResponse<Post> DeletePost(int id);
    }
}
