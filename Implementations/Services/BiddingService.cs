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


        public async Task<BaseResponse> GetBidderByAuctionIdAsync(int id)
        {
            var bid = await _biddingRepository.GetBiddingByAuctionIdAsync(id);
            if (bid == null)
            {
                return new BaseResponse
                {
                    Message = "Bidders could not be found",
                    Success = false,
                };

            }
            return new BiddingResponse
            {
                Data = new BiddingDto
                {

                    Price = bid.Price,

                },
                Message = "Bidders Successfully Retrieved",
                Success = true,

            };
        }

        public async Task<BiddingResponse> GetHighestBidderAsync(int id)
        {
            var bidder = await _biddingRepository.GetHighestBidderAsync(id);
            if (bidder == null)
            {
                return new BiddingResponse()
                {
                    Message = "Highest bidder was not found",
                    Success = false,
                };
            }
            return new BiddingResponse()
            {
                Message = "Highest bidder Found",
                Success = true,
            };

        }

        public async Task<BaseResponse> TerminateBiddingAsync(int id)
        {
            var bid = await _biddingRepository.GetAsync(bid => bid.IsDeleted == false && bid.Id == id);
            if (bid == null)
            {
                return new BaseResponse
                {
                    Message = "Bid does not exist",
                    Success = false
                };
            }
            bid.IsDeleted = true;
            await _biddingRepository.UpdateAsync(bid);
            return new BaseResponse
            {
                Message = "Bid Successfully Terminated",
                Success = true
            };
        }

        public async Task<BaseResponse> CreateBiddingAsync(CreateBiddingRequestModels createBidding)
        {
            var bidding = new Bidding
            {
                Price = createBidding.Price,
                AssetId = createBidding.AuctionId,
                CustomerId = createBidding.CustomerId

            };
            var response = await _biddingRepository.CreateAsync(bidding);
            if (bidding == null)
            {
                return new BaseResponse
                {
                    Message = "Couldn't place bid",
                    Success = false,
                };
            }
            return new BaseResponse
            {
                Message = "You've successfully placed a bid",
                Success = true,
            };
        }

        public async Task<BaseResponse> IncreaseBiddingPriceAsync(int id, UpdateBiddingRequestModels updateBidding)
        {
            var bid = await _biddingRepository.GetAsync(bid => bid.IsDeleted == false && bid.Id == id);
            var bidding = new Bidding
            {
                Price = updateBidding.Price
            };
            var response = await _biddingRepository.UpdateAsync(bidding);
            if (bidding == null)
            {
                return new BaseResponse
                {
                    Message = "Couldn't update bid",
                    Success = false,
                };
            }
            return new BaseResponse
            {
                Message = "You've successfully increased your bidding price",
                Success = true,
            };
        }
    }
}