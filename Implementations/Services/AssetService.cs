using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;

using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Implementation.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _repository;
        public AssetService(IAssetRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse> CreateAssetAsync(CreateAssetRequestModel model)
        {
            var asset = await _repository.GetAsync(mod => mod.AssetName == model.AssetName);
            if (asset != null)
            {

                return new BaseResponse()
                {
                    Message = "Asset already exist",
                    Success = false,

                };
            }
            var ass = new Asset()
            {
                StartingPrice = model.StartingPrice,
                AssetName = model.AssetName,
                IsOpened = model.IsOpened,
                AutioneerId = model.AutioneerId,
            };

            var result = await _repository.CreateAsync(ass);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Asset Creation Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Asset Created Successfully",
                    Success = true,
                };
            }
        }
        public async Task<BaseResponse> ChangeAssetPriceAsync(int id, decimal StartingPrice)
        {
            var asset = await _repository.GetAsync(id);
            if (asset != null)
            {
                return new BaseResponse()
                {
                    Message = "Asset Not Found",
                    Success = false,
                };
            }


            var result = await _repository.UpdateAsync(asset);
            if (result == null)
            {
                return new BaseResponse()
                {
                    Message = "Asset Price Change Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Asset Price Changed Successfully",
                    Success = true,
                };
            }
        }

        public async Task<BaseResponse> GetAssetsByAuctionDateAsync(DateTime Date)
        {
            var asset = await _repository.GetAssetsByAuctionDateAsync(Date);

            if (asset == null)
            {
                return new AssetResponse()
                {
                    Message = "No Assets found for Auctioning",
                    Success = false,
                };
            }
            return new AssetResponse
            {
                Data = asset.select(asset => new AssetDto{
                    StartingPrice = asset.StartingPrice,
                    AssetName = asset.AssetName,
                    IsOpened = asset.IsOpened,
                    AutioneerId = asset.AutioneerId,
                    Auction = asset.Auction,
                    Auctioneer = asset.Auctioneer,
                    BuyerId = asset.BuyerId,
                    Buyer = asset.Buyer,
                    Biddings = asset.Biddings,
                    IsAuctioned = asset.IsAuctioned,
                }).ToList(),
                Message = "Assets found successfully",
                Success = true,
                
            };
           

        }
        public async Task<BaseResponse> DeleteAssetAsync(int id)
        {
            var asset = await _repository.GetAsync(id);
            if (asset != null)
            {
                return new BaseResponse()
                {
                    Message = "No Asset found",
                    Success = false,
                };
            }
            var ass = await _repository.DeleteAsync(asset);
            if (ass == null)
            {
                return new BaseResponse()
                {
                    Message = "Asset Deletion Failed",
                    Success = false,
                };
            }
            else
            {
                return new BaseResponse()
                {
                    Message = "Asset deleted Successfully",
                    Success = true,
                };
            }


        }
        public async Task<BaseResponse> GetAssetsToDisplayAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse> GetAssetsToDisplayAsync(CreateAssetRequestModel model)
        {
            throw new NotImplementedException();
        }
    }


}



