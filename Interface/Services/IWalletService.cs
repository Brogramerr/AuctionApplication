using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs;
namespace AuctionApplication.Interface.Services
{
    public interface IWalletService
    {
        Task<BaseResponse> CreateWalletAsync(CreateWalletRequestModel walletRequestModel);
        Task<BaseResponse> FundWalletAsync(int id, FundWalletRequestModel fundWalletRequestModel);
        Task<BaseResponse> WithdrawFundsAsync(int id, WithdrawFundsRequestModel withdrawFundsRequestModel);
        Task<BaseResponse> GetWalletAsync(int id, WalletDto getWallet);
    }
}