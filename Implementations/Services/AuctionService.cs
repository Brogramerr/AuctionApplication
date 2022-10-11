using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using System;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Interface.Repositories;

using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Entities;

namespace AuctionApplication.Implementation.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly IAuctionRepository _repository;
        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }





        
        public async Task<BaseResponse> CreateAuctionAsync(CreateAuctionRequestModels model)
        {
            var auction = await _repository.GetAsync(model => model.Assets == model.Assets);
            if (auction != null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Already Exist",
                    Success = false,
                };
            }

            var auc = new Auction()
            {
                OpeningDate = model.OpeningDate,
                Duration = model.Duration,
            };

            var result = await _repository.CreateAsync(auc);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Creation Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Auction Created Successfully",
                    Success = true,
                };
            }
        }

        public async Task<BaseResponse> DeleteAuctionAsync(int id)
        {
            var auction = await _repository.GetAsync(id);
            if (auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not Found",
                    Success = false,
                };
            }
            var result = await _repository.DeleteAsync(auction);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Deletion Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Auction Deleted Successfully",
                    Success = true,
                };
            }
        }

        public async Task<BaseResponse> ChangeAuctionPriceAsync(int id, decimal price)
        {
            var auction = await _repository.GetAsync(id);
            if (auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not Found",
                    Success = false,
                };
            }

            
            var result = await _repository.UpdateAsync(auction);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Price Change Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Auction Price Changed Successfully",
                    Success = true,
                };
            }
        }

        public Task<BaseResponse> ApproveAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> DisApproveAuction(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> ExtendAuctionExpiryDate(int id, DateTime ExpiryDate)
        {
            throw new NotImplementedException();
        }
    }
}