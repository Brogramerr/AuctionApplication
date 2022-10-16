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

            var user = _repository.GetAsync(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                return new UserResponseModel
                {
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