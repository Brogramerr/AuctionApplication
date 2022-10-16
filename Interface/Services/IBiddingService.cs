using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;

using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.DTOs.RequestModels;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;

namespace AuctionApplication.Interface.Services
{
    public interface IBiddingService
    {
        Task<BaseResponse> CreateBiddingAsync(CreateBiddingRequestModels createBidding);
        Task<BaseResponse> IncreaseBiddingPriceAsync(UpdateBiddingRequestModels updateBidding);
        Task<BaseResponse> TerminateBiddingAsync(int id);
        Task<BiddingsResponseModel> GetBiddingByAssetIdAsync(int id);
        Task<BiddingResponseModel> GetHighestBidder();


    }
}