using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Implementation.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ICustomerRepository _customerRepository;
        public WalletService(IWalletRepository walletRepository, ICustomerRepository customerRepository)
        {
            _walletRepository = walletRepository;
            _customerRepository = customerRepository;
        }

        
       public async Task<BaseResponse> FundWalletAsync(FundWalletRequestModel fundWalletRequestModel)
        {
            var customer = await _customerRepository.GetCustomer(fundWalletRequestModel.CustomerId);
            customer.Wallet.Amount += fundWalletRequestModel.Amount;

            await _walletRepository.UpdateAsync(customer.Wallet);
            
            return new BaseResponse
            {
                Message = "You've successfully funded your wallet",
                Success = true,
            };
        }

        public async Task<WalletResponseModel> GetWalletBalance(int customerId)
        {
            var customer = await _customerRepository.GetCustomer(customerId);
            
            return new WalletResponseModel
            {
                Data = new WalletDto
                {
                    Amount = customer.Wallet.Amount
                },
                Message = "Balance Successfully Retrieved",
                Success = true,

            };
        }

        public async Task<BaseResponse> WithdrawFundsAsync(WithdrawFundsRequestModel withdrawFundsRequestModel)
        {
            var customer = await _customerRepository.GetCustomer(withdrawFundsRequestModel.CustomerId);
            customer.Wallet.Amount -= withdrawFundsRequestModel.Amount;

            await _walletRepository.UpdateAsync(customer.Wallet);

            return new BaseResponse
            {
                Message = "You've successfully withdraw from your wallet",
                Success = true,
            };
        }
    }
}
