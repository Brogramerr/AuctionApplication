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

        public UserResponseModel Login(string email, string passWord)
        {

            var user = _repository.ExistsByEmailAsync(email, passWord);
            if (user = !null)
            {
                return new BaseResponse
                {
                    Success = true,
                    Message = "Sucessfully logged in",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Loggin Failed",
            };
        }
    }
}