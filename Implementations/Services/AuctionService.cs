using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using System;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Enum;

namespace AuctionApplication.Implementation.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly IAuctionRepository _repository;
        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> ApproveAuction(int id)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.IsApproved = true;
              await  _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction Approved Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction Approval Failed",
            };
        }
        public async Task<BaseResponse> DisApproveAuction(int id)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.IsApproved = false;
                await _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction DisApproved Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction DisApproval Failed",
            };
        }
        public async Task<BaseResponse> ExtendAuctionExpiryDate(int id, DateTime ExpiryDate)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.ExpiryDate = ExpiryDate;
                await _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction Expiry Date Extended Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction Expiry Date Extention Failed",
            };
        }
        public async Task<BaseResponse> UpdateAsset(int id, string AssetName)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.AssetName = AssetName;
                await _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction Asset Updated Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction Asset Update Failed",
            };
        }
        public async Task<BaseResponse> ChangeAuctionType(int id, AuctionType AuctionType)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.AuctionType = AuctionType;
                await _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction Type Updated Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction Type Update Failed",
            };
        }
        public async Task<BaseResponse> CloseAuction(int id)
        {

            var auction = await _repository.GetAsync(id);
            if (auction != null)
            {
                auction.IsClosed = true;
                await _repository.UpdateAsync(auction);
                return new BaseResponse
                {
                    Success = true,
                    Message = "Auction Closed Sucessfully",
                };
            }
            return new BaseResponse
            {
                Success = false,
                Message = "Auction Closure Failed",
            };
        }
    }
}