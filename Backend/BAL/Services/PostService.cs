using AutoMapper;
using Blog.BAL.IServices;
using Blog.DAL.Entity;
using Blog.DAL.IRepository;
using Blog.DAL.Repository;
using Blog.Helper;
using Blog.Models;
using static Blog.Helper.Enum;

namespace Blog.BAL.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _PostRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepository pmrepo, IMapper mapper)
        {
            _PostRepo = pmrepo;
            _mapper = mapper;
        }

        public async Task<int> CreatePost(PostModel pm)
        {
            Post? newPost = _mapper.Map<Post>(pm);
            newPost.CreatedBy = (int)RoleTypeEnum.ADMIN;
            newPost.CreatedDate = DateTime.Now;
            if (_PostRepo.Add(newPost))
            {
                _PostRepo.SaveChangesManaged();
            }
            return newPost.Id;
        }

        public ServiceResponse<Post> UpdatePost(int id, PostModel postModel)
        {
            var response = new ServiceResponse<Post>();

            try
            {
                var existingPost = _PostRepo.GetById(id);
                if (existingPost == null)
                {
                    response.ApiResponseStatus = APIResponseStatus.Error;
                    response.ErrorMessage = "Post not found.";
                    return response;
                }

                // Update fields
                existingPost.Title = postModel.title;
                existingPost.Description = postModel.description;
                _PostRepo.Update(existingPost);
                _PostRepo.SaveChangesManaged();

                response.result = existingPost;
                response.ApiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.ApiResponseStatus = APIResponseStatus.Error;
                response.ErrorMessage = "An error occurred while updating the post: " + ex.Message;
            }

            return response;
        }

        public ServiceResponse<Post> DeletePost(int id)
        {
            var response = new ServiceResponse<Post>();

            try
            {
                var existingPost = _PostRepo.GetById(id);
                if (existingPost == null)
                {
                    response.ApiResponseStatus = APIResponseStatus.Error;
                    response.ErrorMessage = "Post not found.";
                    return response;
                }

                // Update fields
                existingPost.IsPublished = false;
                _PostRepo.Update(existingPost);
                _PostRepo.SaveChangesManaged();

                response.result = existingPost;
                response.ApiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.ApiResponseStatus = APIResponseStatus.Error;
                response.ErrorMessage = "An error occurred while updating the post: " + ex.Message;
            }

            return response;
        }

    }
}
