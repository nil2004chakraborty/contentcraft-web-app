using AutoMapper;
using Blog.DAL.Entity;
using Blog.Models;

namespace Blog.Helper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<UserModel, User>().ReverseMap();
            CreateMap<PostModel, Post>().ReverseMap();
            CreateMap<UserModel, User>();
            CreateMap<PostModel, Post>();
        }
    }
}
