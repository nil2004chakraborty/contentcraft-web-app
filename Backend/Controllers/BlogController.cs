using Blog.BAL.IServices;
using Blog.BAL.Services;
using Blog.DAL.DBContext;
using Blog.DAL.Entity;
using Blog.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Blog.Helper.Enum;

namespace Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        BlogContext _bContext;
        IPostService _postService;
        private readonly IUserService _userService;
        public BlogController(IUserService us, IPostService ps, BlogContext bContext)
        {
            // _eContext= ec;
            _userService = us;
            _postService = ps;
            _bContext = bContext;
        }

        //Endpoint to create a new user.
        [HttpPost("AddUser")]
        public async Task<int> AddEmployee(UserModel u)
        {
            try
            {
                int result = await _userService.CreateUser(u);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //Endpoint to create a new post.
        [HttpPost("AddPost")]
        public async Task<int> AddPost(PostModel p)
        {
            //try-catch block
            try
            {
                int result = await _postService.CreatePost(p);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        //Endpoint to get all users.
        [HttpGet("GetUserDetails")]
        public List<User> GetUserDetails()
        {
            List<User> users = _bContext.Users.ToList();

            return users;
        }


        //Endpoint to get all published posts.
        [HttpGet("GetPostDetails")]
        public List<Post> GetPostDetails()
        {
            List<Post> posts = _bContext.Posts.ToList();

            return posts;
        }


        //Endpoint to get a published post by ID.
        [HttpGet("GetPostDetailsById/{id}")]
        public Post GetPost(int id)
        {
            Post es = _bContext.Posts.Where(e => e.Id == id)
                .SingleOrDefault();
            return es;


        }


        //Endpoint to get a published post of an active user by ID.
        [HttpGet("GetActivePostDetailsById/{id}")]
        public Post GetActivePost(int id)
        {
            /*Post es = _bContext.Posts.Where(e => e.Id == id && e.User.IsActive)
                .SingleOrDefault();
            return es;*/
            var post = (from p in _bContext.Posts
                        join u in _bContext.Users on p.CreatedBy equals u.Id
                        where p.Id == id && u.IsActive == true
                        select p).SingleOrDefault();

            return post;

        }


        //Endpoint to get published posts by category.
        [HttpGet("GetPostsByCategory/{Category}")]
        public List<Post> GetPostsByCategory(int Category)
        {
            List<Post> posts = _bContext.Posts
                .Where(e => e.Category == Category)
                .ToList();
            return posts;
        }


        //Endpoint to update user details e.g. name, password.
        [HttpPut("UpdateUserByID/{id}")]
        public IActionResult UpdateUser(int id, UserModel userModel)
        {
            var response = _userService.UpdateUser(id, userModel);

            if (response.ApiResponseStatus == APIResponseStatus.Error)
            {
                return StatusCode(500, response);
            }

            // Assuming response.Data contains the updated user
            return Ok(response.result);
        }


        //Endpoint to update post details e.g. title, description.
        [HttpPut("UpdatePostByID/{id}")]
        public IActionResult UpdatePost(int id, PostModel postModel)
        {
            var response = _postService.UpdatePost(id, postModel);

            if (response.ApiResponseStatus == APIResponseStatus.Error)
            {
                return StatusCode(500, response);
            }

            return NoContent();
        }

        //Endpoint to delete a user (soft delete by setting ‘is_active’ as false).
        [HttpPatch("DeleteUserByID/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var response = _userService.DeleteUser(id);

            if (response.ApiResponseStatus == APIResponseStatus.Error)
            {
                return StatusCode(500, response);
            }

            return NoContent();
        }
        

        //Endpoint to delete a post(soft delete by setting ‘is_published’ as false).
        [HttpPatch("DeletePostByID/{id}")]
        public IActionResult DeletePost(int id)
        {
            var response = _postService.DeletePost(id);

            if (response.ApiResponseStatus == APIResponseStatus.Error)
            {
                return StatusCode(500, response);
            }

            return NoContent();
        }
       

      








        

    }
}



    
   
