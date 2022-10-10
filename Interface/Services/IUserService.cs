using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
namespace AuctionApplication.Interface.Services
{
    public interface IUserService
    {
        UserResponseModel Login(string email, string passWord);
     
    }
}