using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
namespace AuctionApplication.Interface.Services
{
    public interface IUserService
    {
        Task<UserResponseModel> Login(string email, string passWord);
     
    }
}