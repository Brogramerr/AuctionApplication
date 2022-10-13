using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;
using AuctionApplication.DTOs.RequestModels;
using AuctionApp.Entities.Enums;


namespace AuctionApplication.Implementation.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        public AssetService(IAssetRepository repository)
        {
            _assetRepository = repository;
        }
        public async Task<BaseResponse> CreateAssetAsync(CreateAssetRequestModel model)
        {
            var ass = new Asset
            {
                Price = model.Price,
                SoldPrice = model.Price,
                AssetName = model.AssetName,
                AuctionPriceIsOpened = model.AuctionPriceIsOpened,
                AutioneerId = model.AutioneerId,
                AssetStatus = AssetStatus.NotAuctioned
            };

            var result = await _assetRepository.CreateAsync(ass);
            return new BaseResponse
            {
                Message = "Asset Created Successfully",
                Success = true,
            };
        }
        public async Task<BaseResponse> ChangeAssetPriceAsync(int id, decimal Price)
        {
            var asset = await _assetRepository.GetAsync(id);
            if (asset == null)
            {
                return new BaseResponse()
                {
                    Message = "Asset Not Found",
                    Success = false,
                };
            }

            asset.Price = Price;
            await _assetRepository.UpdateAsync(asset);

            return new BaseResponse()
            {
                Message = "Asset Price Changed Successfully",
                Success = true,
            };
        }

        public async Task<AssetsResponseModel> GetAssetsByAuctionDateAsync(DateTime Date)
        {
            var asset = await _assetRepository.GetAssetsByAuctionDateAsync(Date);
            if (asset == null)
            {
                return new AssetsResponseModel
                {
                    Message = $"No Assets found for {Date}",
                    Success = false,
                };
            }
            return new AssetsResponseModel
            {
                Data = asset.Select(asset => new AssetDto
                {
                    Price = asset.Price,
                    AssetName = asset.AssetName,
                    AuctionPriceIsOpened = asset.AuctionPriceIsOpened,
                    Auctioneer = asset.Auctioneer.Username,
                    Buyer = asset.Buyer.Username,
                    AssetStatus = asset.AssetStatus,
                }).ToList(),
                Message = "Assets found successfully",
                Success = true,

            };

        }
        public async Task<BaseResponse> DeleteAssetAsync(int id)
        {
            var asset = await _assetRepository.GetAsync(x => x.Id == id && x.IsDeleted == false);
            if (asset == null)
            {
                return new BaseResponse()
                {
                    Message = "No Asset found",
                    Success = false,
                };
            }
            bool check = asset.Auction.OpeningDate == DateTime.Now;
            if (check)
            {
                return new BaseResponse()
                {
                    Message = "Unable to delete asset because the auction is on",
                    Success = false,
                };
            }
            asset.IsDeleted = true;
            await _assetRepository.UpdateAsync(asset);
            return new BaseResponse()
            {
                Message = "Asset Deletion Successful",
                Success = true
            };
        }
        public async Task<AssetsResponseModel> GetAssetsToDisplayAsync()
        {
            var assetToDisplay = await _assetRepository.GetAssetsToDisplayAsync();
            if (assetToDisplay.Count == 0)
            {
                return new AssetsResponseModel
                {
                    Message = "No Asset available for auction today",
                    Success = false
                };
            }
            return new AssetsResponseModel
            {
                Data = assetToDisplay.Select(a => new AssetDto
                {
                    AssetId = a.Id,
                    AssetName = a.AssetName,
                    AssetStatus = a.AssetStatus,
                    Auctioneer = a.Auctioneer.Username,
                    AuctionPriceIsOpened = a.AuctionPriceIsOpened,
                    Price = a.Price,
                }).ToList(),
                Message = "Assets available for auction today",
                Success = true
            };
        }

        public async Task<BaseResponse> ChangeAssetStatusToAuctioned(int id)
        {
            var toAuctioned = await _assetRepository.GetAsync(id);
            if (toAuctioned.AssetStatus == AssetStatus.NotAuctioned && toAuctioned.IsDeleted == false && toAuctioned.AssetStatus != AssetStatus.Sold)
            {
                toAuctioned.AssetStatus = AssetStatus.Auctioned;
                await _assetRepository.UpdateAsync(toAuctioned);
                return new BaseResponse
                {
                    Message = "Asset is now Auctioned",
                    Success = true,
                };
            }
            return new BaseResponse
            {
                Message = "Unable to put asset up for auction",
                Success = false,
            };
        }

        public async Task<BaseResponse> ChangAssetStatusToSold(int id)
        {
            var asset = await _assetRepository.GetAsync(id);
            if (asset == null)
            {
                return new BaseResponse
                {
                    Message = "Asset not found",
                    Success = false
                };
            }
            asset.AssetStatus = AssetStatus.Sold;
            await _assetRepository.UpdateAsync(asset);
            return new BaseResponse
            {
                Message = "Asset status change to sold",
                Success = true
            };
        }

    }

}







