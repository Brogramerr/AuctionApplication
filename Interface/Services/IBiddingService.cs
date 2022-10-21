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
        Task<BaseResponse> CreateBiddingAsync(CreateBiddingRequestModels createBidding,int id);
        Task<BaseResponse> IncreaseBiddingPriceAsync(UpdateBiddingRequestModels updateBidding,int id);
        Task<BaseResponse> TerminateBiddingAsync(int id);
        Task<BiddingsResponseModel> GetBiddingByAssetIdAsync(int id);
        Task<BiddingResponseModel> GetBiddingByIdCustomerId(int id, int assetId);
        Task<BiddingResponseModel> GetHighestBidder();


    }
}