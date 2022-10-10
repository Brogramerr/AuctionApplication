using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;

using Microsoft.EntityFrameworkCore;


namespace AuctionApplication.Implementation.Services
{
    public class UserService:IUserService

    {
        private readonly UserRepository _repository;
        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponse> Login(string email, string passWord)
        {

            var user = _repository.ExistsByEmailAsync(email, passWord);
            if (user = !null)
            {
                return new UserResponse
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
            return new UserResponse
            {
                Success = false,
                Message = "Loggin Failed",
            };
        }
    }
}