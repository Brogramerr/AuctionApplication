using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Interface.Services
{
    public interface IWalletService
    {
        Task<BaseResponse> CreateWalletAsync(CreateWalletRequestModel walletRequestModel);
    }
}