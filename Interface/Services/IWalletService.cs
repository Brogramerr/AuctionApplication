using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs;
namespace AuctionApplication.Interface.Services
{
    public interface IWalletService
    {
        Task<BaseResponse> FundWalletAsync(FundWalletRequestModel fundWalletRequestModel);
        Task<WalletResponseModel> GetWalletBalance(int customerId);
        Task<BaseResponse> WithdrawFundsAsync(WithdrawFundsRequestModel withdrawFundsRequestModel);
    }
}