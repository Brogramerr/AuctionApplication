using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using System;
using Microsoft.EntityFrameworkCore;


namespace AuctionApplication.Implementation.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly AuctionRepository _repository;
        public AuctionService(AuctionRepository repository)
        {
            _repository = repository;
        }

        public BaseResponse ApproveAuction(int id)
        {

            var auction = _repository.GetAsync(id);
            if (action = !null)
            {
                auction.IsApproved = true;
                _repository.UpdateAsync(auction);
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
        public BaseResponse DisApproveAuction(int id)
        {

            var auction = _repository.GetAsync(id);
            if (action = !null)
            {
                auction.IsApproved = false;
                _repository.UpdateAsync(auction);
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
        public BaseResponse ExtendAuctionExpiryDate(int id, DateTime ExpiryDate)
        {

            var auction = _repository.GetAsync(id);
            if (action = !null)
            {
                auction.ExpiryDate = ExpiryDate;
                _repository.UpdateAsync(auction);
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
        public BaseResponse UpdateAsset(int id, string AssetName)
        {

            var auction = _repository.GetAsync(id);
            if (action = !null)
            {
                auction.AssetName = AssetName;
                _repository.UpdateAsync(auction);
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
        public BaseResponse ChangeAuctionType(int id, AuctionType AuctionType)
        {

            var auction = _repository.GetAsync(id);
            if (action = !null)
            {
                auction.AuctionType = AuctionType;
                _repository.UpdateAsync(auction);
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
    }
}