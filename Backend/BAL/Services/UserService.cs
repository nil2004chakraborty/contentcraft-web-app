using AutoMapper;
using Blog.BAL.IServices;
using Blog.DAL.Entity;
using Blog.DAL.IRepository;
using Blog.DAL.Repository;
using Blog.Helper;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using static Blog.Helper.Enum;

namespace Blog.BAL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository umrepo, IMapper mapper)
        {
            _UserRepo = umrepo;
            _mapper = mapper;
           
            
        }

        public async Task<int> CreateUser(UserModel um)
        {
            User? newUser = _mapper.Map<User>(um);
            if (_UserRepo.Add(newUser))
            {
                _UserRepo.SaveChangesManaged();
            }
            return newUser.Id;
        }

        public ServiceResponse<User> UpdateUser(int id, UserModel userModel)
        {
            var response = new ServiceResponse<User>();

            try
            {
                var existingUser = _UserRepo.GetById(id);
                if (existingUser == null)
                {
                    response.ApiResponseStatus = APIResponseStatus.Error;
                    response.ErrorMessage = "User not found.";
                    return response;
                }

                // Update fields
                existingUser.Name = userModel.name;
                existingUser.Password = HashPassword(userModel.password); // Assuming you have a method to hash passwords
                _UserRepo.Update(existingUser);
                _UserRepo.SaveChangesManaged();

                response.result = existingUser;
                response.ApiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.ApiResponseStatus = APIResponseStatus.Error;
                response.ErrorMessage = "An error occurred while updating the user: " + ex.Message;
            }

            return response;
        }
        private string HashPassword(string password)
        {
            // Implement your password hashing logic here
            return password; // This is a placeholder
        }

        public ServiceResponse<User> DeleteUser(int id)
        {
            var response = new ServiceResponse<User>();

            try
            {
                var existingUser = _UserRepo.GetById(id);
                if (existingUser == null)
                {
                    response.ApiResponseStatus = APIResponseStatus.Error;
                    response.ErrorMessage = "User not found.";
                    return response;
                }

                // Update fields
                existingUser.IsActive = false;
                _UserRepo.Update(existingUser);
                _UserRepo.SaveChangesManaged();

                response.result = existingUser;
                response.ApiResponseStatus = APIResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.ApiResponseStatus = APIResponseStatus.Error;
                response.ErrorMessage = "An error occurred while updating the user: " + ex.Message;
            }

            return response;
        }
        
    }
}
