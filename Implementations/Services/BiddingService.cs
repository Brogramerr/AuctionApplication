using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Implementation.Services
{
    public class BiddingService : IBiddingService

    {
        private readonly IBiddingRepository _biddingRepository;
        private readonly IAssetRepository _assetRepository;


        public BiddingService(IBiddingRepository biddingRepository, IAssetRepository assetRepository)
        {
            _biddingRepository = biddingRepository;
            _assetRepository = assetRepository;
        }

        public async Task<BaseResponse> CreateBiddingAsync(CreateBiddingRequestModels createBidding, int id)
        {
            var bid = await _biddingRepository.GetAsync(x => x.CustomerId == createBidding.CustomerId && x.AssetId == id);
            if (bid != null)
            {
                return new BaseResponse()
                {
                    Message = "You have already placed a bid on this asset",
                    Success = false,
                };
            }
            var asset = await _assetRepository.GetAsync(id);
            if(asset.AutioneerId == createBidding.CustomerId) return new BaseResponse()
            {
                Message = "Auctioneer cannot bid on asset",
                Success = false,
            };
            var bidding = new Bidding
            {
                CustomerId = createBidding.CustomerId,
                Price = createBidding.Price,
                AssetId = id
            };
            await _biddingRepository.CreateAsync(bidding);
            return new BaseResponse()
            {
                Message = "Bidding successfully created",
                Success = true,
            };
        }

        public async Task<BiddingsResponseModel> GetBiddingByAssetIdAsync(int id)
        {
            var bidding = await _biddingRepository.GetBiddingsByAssetIdAsync(id);
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
        public async Task<BaseResponse> IncreaseBiddingPriceAsync(UpdateBiddingRequestModels updateBidding, int id)
        {
            var bidding = await _biddingRepository.GetAsync(x => x.AssetId == id && x.CustomerId == updateBidding.CustomerId);
            if (bidding == null)
            {
                return new BaseResponse()
                {
                    Message = "Bidding not found",
                    Success = false,
                };
            }
            bidding.Price = updateBidding.Price;
            await _biddingRepository.UpdateAsync(bidding);
            return new BaseResponse()
            {
                Message = "Bidding price increased successfully",
                Success = true,
            };
        }

        public async Task<BaseResponse> TerminateBiddingAsync(int id)
        {
            var bidding = await _biddingRepository.GetAsync(x => x.Id == id);
            if (bidding == null)
            {
                return new BaseResponse
                {
                    Message = "Bidding not found",
                    Success = false,
                };
            }
            await _biddingRepository.DeleteAsync(bidding);
            return new BaseResponse
            {
                Message = "Bidding terminated",
                Success = true,
            };
        }
        public async Task<BiddingResponseModel> GetHighestBidder()
        {
            var getBidder = await _biddingRepository.GetHighestBidderAsync();
            return new BiddingResponseModel
            {
                Data = new BiddingDto
                {
                    AssetName = getBidder.Asset.AssetName,
                    CustomerName = getBidder.Customer.Username,
                    Price = getBidder.Price
                },
                Message = $"Highest Bidder for this asset is {getBidder.Customer.Username}",
                Success = true
            };
        }

        public async Task<BiddingResponseModel> GetBiddingByIdCustomerId(int id, int assetId)
        {
            var bidding = await _biddingRepository.GetAsync(c => c.AssetId == assetId && c.CustomerId == id);
            if(bidding == null)
            {
                return new BiddingResponseModel
                {
                    Message = "Bidding not found",
                    Success = false
                };
            }
            return new BiddingResponseModel
            {
                Message = "Bidding found",
                Success = false,
                Data = new BiddingDto
                {
                    Price = bidding.Price,
                }
            };
        }
    }
}