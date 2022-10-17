using AuctionApplication.DTOs;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Implementation.Services
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseModel> Login(string email, string password)
        {

            var user = await _repository.GetAsync(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                return new UserResponseModel
                {
                    Data = new UserDto(){
                        Email = user.Email,
                        Password = user.Password,
                        Id = user.Id
                    },
                    Success = true,
                    Message = "Sucessfully logged in",
                };
            }
            return new UserResponseModel
            {
                Success = false,
                Message = "Loggin Failed",
            };
        }
    }
}