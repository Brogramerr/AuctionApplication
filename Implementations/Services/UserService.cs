using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;

using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.Interface.Repositories;

namespace AuctionApplication.Implementation.Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> Login(string email, string passWord)
        {

            var user = await _repository.ExistsByEmailAsync(email, passWord);
            if (user != null)
            {
                return new UserResponseModel
                {
                    Data = new UserDto{
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        Username = user.Username
                    },
                    Success = true,
                    Message = "Sucessfully logged in",
                };
            }
            return new UserResponseModel
            {
                Success = true,
                Message = "User not found",
            };
        }
    }
}