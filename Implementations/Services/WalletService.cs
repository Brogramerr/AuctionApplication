using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;

using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;

namespace AuctionApplication.Implementation.Services
{
    public class WalletService : IWalletService
    {
         private readonly IWalletRepository _walletRepository;


        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<BaseResponse> CreateWalletAsync(CreateWalletRequestModel walletRequestModel)
        {
             var wallet = new Wallet
            {
                Amount = walletRequestModel.Amount,
                CustomerId = walletRequestModel.CustomerId

            };
            var response = await _walletRepository.CreateAsync(wallet);
            if (response == null)
            {
                return new BaseResponse
                {
                    Message = "Couldn't create wallet",
                    Success = false,
                };
            }
            return new BaseResponse
            {
                Message = "You've successfully created a wallet",
                Success = true,
            };
        }

        public async Task<BaseResponse> FundWalletAsync(int id, FundWalletRequestModel fundWalletRequestModel)
        {
             var wallet = await _walletRepository.GetWalletAsync(id);
            wallet.Amount += fundWalletRequestModel.Amount;
            
            var response = await _walletRepository.UpdateAsync(wallet);
            if (response == null)
            {
                return new BaseResponse
                {
                    Message = "Couldn't fund wallet",
                    Success = false,
                };
            }
            return new BaseResponse
            {
                Message = "You've successfully funded your wallet",
                Success = true,
            };
        }

        public async Task<BaseResponse> GetWalletAsync(int id, WalletDto getWallet)
        {
             var balance = await _walletRepository.GetAsync(id);
            if (balance == null)
            {
                return new BaseResponse
                {
                    Message = "Wallet could not be found",
                    Success = false,
                };

            }
            return new WalletResponseModel
            {
                Data = new WalletDto
                {

                    Amount = balance.Amount

                },
                Message = "Balance Successfully Retrieved",
                Success = true,

            };
        }

        public async Task<BaseResponse> WithdrawFundsAsync(int id, WithdrawFundsRequestModel withdrawFundsRequestModel)
        {
              var wallet = await _walletRepository.GetWalletAsync(id);
            wallet.Amount -= withdrawFundsRequestModel.Amount;
            var response = await _walletRepository.UpdateAsync(wallet);
            if (response == null)
            {
                return new BaseResponse
                {
                    Message = "Couldn't withdraw funds",
                    Success = false,
                };
            }
            return new BaseResponse
            {
                Message = "You've successfully withdrawn money from your wallet",
                Success = true,
            };
        }
    }
}       
