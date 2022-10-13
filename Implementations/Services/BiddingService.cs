using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.Entities;

namespace AuctionApplication.Implementation.Services
{
    public class BiddingService : IBiddingService

    {
        private readonly IBiddingRepository _biddingRepository;


        public BiddingService(IBiddingRepository biddingRepository)
        {
            _biddingRepository = biddingRepository;
        }

        public async Task<BaseResponse> CreateBiddingAsync(CreateBiddingRequestModels createBidding)
        {
            var bid = await _biddingRepository.GetAsync(x => x.CustomerId == createBidding.CustomerId);
            if (bid != null)
            {
                return new BaseResponse()
                {
                    Message = "You have already placed a bid",
                    Success = false,
                };
            }
            var bidding = new Bidding
            {
                CustomerId = createBidding.CustomerId,
                Price = createBidding.Price,
                AssetId = createBidding.AssestId,
            };
            var result = await _biddingRepository.CreateAsync(bidding);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding created successfully",
                    Success = true,
                };
            }
            return new BaseResponse()
            {
                Message = "Bidding not created",
                Success = false,
            };
        }

        public async Task<BiddingsResponseModel> GetBiddingByAssetIdAsync(int id)
        {
            var bidding = await _biddingRepository.GetBiddingByAssetIdAsync(id);
            if (bidding == null)
            {
                return new BiddingsResponseModel()
                {
                    Message = "Bidding not found",
                    Success = false,
                };
            }
            return new BiddingsResponseModel()
            {
                Message = "Bidding found",
                Success = true,
                Bidding = bidding.Select(x => new BiddingDto()
                {
                    Price = x.Price,
                    CustomerName = x.Customer.FirstName + " " + x.Customer.LastName,
                    AssetName = x.Asset.AssetName,
                }).ToList(),
            };
        }


        public async Task<BaseResponse> IncreaseBiddingPriceAsync(int id, UpdateBiddingRequestModels updateBidding)
        {
            var bidding = await _biddingRepository.GetAsync(x => x.Id == id);
            if (bidding == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding not found",
                    Success = false,
                };
            }
            bidding.Price = updateBidding.Price;
            var result = await _biddingRepository.UpdateAsync(bidding);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding updated successfully",
                    Success = true,
                };
            }
            return new BaseResponse()
            {
                Message = "Bidding not updated",
                Success = false,
            };
        }

        public async Task<BaseResponse> TerminateBiddingAsync(int id)
        {
            var bidding = await _biddingRepository.GetAsync(x => x.Id == id);
            if (bidding == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding not found",
                    Success = false,
                };
            }
            var result = await _biddingRepository.DeleteAsync(bidding);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding terminated successfully",
                    Success = true,
                };
            }
            return new BaseResponse()
            {
                Message = "Bidding not terminated",
                Success = false,
            };
        }
    }
}