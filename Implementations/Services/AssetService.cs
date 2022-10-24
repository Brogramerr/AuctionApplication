using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Entities.Enums;


namespace AuctionApplication.Implementation.Services
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;
        private readonly IBiddingRepository _biddingRepository;
        private readonly ICustomerRepository _customerRepository;
         private readonly  IWebHostEnvironment _webHostEnvironment;

        public AssetService(IAssetRepository repository, ICustomerRepository customerRepository,IBiddingRepository biddingRepository,IWebHostEnvironment webHostEnvironment)
        {
            _assetRepository = repository;
            _customerRepository = customerRepository;
            _biddingRepository = biddingRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<BaseResponse> CreateAssetAsync(int autioneerId, CreateAssetRequestModel model)
        {
            var customer = await _customerRepository.GetAsync(x => x.UserId == autioneerId);
            if(customer == null)
            {
                return new BaseResponse
                {
                    Message = "Auctioneer not found",
                    Success = false
                };
            }
            var imageName = "";
            if(model.ImageUrl != null)
            {
                var imgPath = _webHostEnvironment.WebRootPath;
                var imagePath  = Path.Combine(imgPath,"images");
                Directory.CreateDirectory(imagePath);
                var imageType = model.ImageUrl.ContentType.Split('/')[1];
                imageName = $"{Guid.NewGuid()}.{imageType}";
                var fullPath = Path.Combine(imagePath,imageName);
                using(var fileStream = new FileStream(fullPath,FileMode.Create))
                {
                    model.ImageUrl.CopyTo(fileStream);
                }
            }
            var ass = new Asset
            {
                Price = model.Price,
                AssetName = model.AssetName,
                AuctionPriceIsOpened = model.AuctionPriceIsOpened,
                AssetStatus = AssetStatus.NotAuctioned, 
                AutioneerId = customer.Id,
                ImageUrl = imageName
                
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
                    Price = Math.Ceiling(asset.Price),
                    AssetName = asset.AssetName,
                    AuctionPriceIsOpened = asset.AuctionPriceIsOpened,
                    Auctioneer = asset.Autioneer.Username,
                    AssetStatus = asset.AssetStatus,
                    ImageUrl = asset.ImageUrl 
                }).ToList(),
                Message = "Assets found successfully",
                Success = true,

            };

        }
        public async Task<AssetResponseModel> GetAssetsById(int id)
        {
            var asset = await _assetRepository.GetAsync(id);
            if (asset == null)
            {
                return new AssetResponseModel
                {
                    Message = $"Asset not found",
                    Success = false,
                };
            }
            var bidding = await _biddingRepository.GetBiddingsByAssetIdAsync(asset.Id);
            return new AssetResponseModel
            {
                Message = "Assets found successfully",
                Success = true,
                Data =  new AssetDto
                {
                    AssetId = asset.Id,
                    Price = Math.Ceiling(asset.Price),
                    AssetName = asset.AssetName,
                    AuctionPriceIsOpened = asset.AuctionPriceIsOpened,
                    Auctioneer = asset.Autioneer.Username,
                    ImageUrl = asset.ImageUrl, 
                    AssetStatus = asset.AssetStatus,
                    HighestBid = Math.Ceiling(_biddingRepository.GetHighestBiddingPriceByAssetIdAsync(asset.Id)),
                    Biddings = bidding.Select(bid => new BiddingDto(){
                        CustomerName = bid.Customer.Username,
                        Price = Math.Ceiling(bid.Price),
                    }).ToList(),
                }

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
                Data = assetToDisplay.Select( a => new AssetDto
                {
                    AssetId = a.Id,
                    AssetName = a.AssetName,
                    AssetStatus = a.AssetStatus,
                    Auctioneer = a.Autioneer.Username,
                    ImageUrl = a.ImageUrl, 
                    AuctionPriceIsOpened = a.AuctionPriceIsOpened,
                    Price = Math.Ceiling(a.Price),   
                    HighestBid = Math.Ceiling(_biddingRepository.GetHighestBiddingPriceByAssetIdAsync(a.Id))
                }).ToList(),
            };
        }

        public async Task<BaseResponse> ChangeAssetStatusToAuctioned(int id)
        {
            var toAuctioned = await _assetRepository.GetAsync(id);
            if (toAuctioned == null) return new BaseResponse
            {
                Message = "Asset not found",
                Success = false,
            };
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
            if (asset.AssetStatus == AssetStatus.Auctioned && asset.IsDeleted == false && asset.AssetStatus != AssetStatus.Sold)
            {
                asset.AssetStatus = AssetStatus.Sold;
                await _assetRepository.UpdateAsync(asset);
                return new BaseResponse
                {
                    Message = "Asset status change to sold",
                    Success = true
                };
            }
            return new BaseResponse
            {
                Message = "Asset is either not on any auction or sold",
                Success = false
            };
        }
        public async Task<BaseResponse> AddAssetForAuctionAsync(int id)
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
            if (asset.AssetStatus == AssetStatus.NotAuctioned && asset.IsDeleted == false)
            {
                asset.AssetStatus = AssetStatus.Auctioned;
                await _assetRepository.UpdateAsync(asset);
                return new BaseResponse
                {
                    Message = "Asset is now in an auction",
                    Success = true
                };
            }
            return new BaseResponse
            {
                Message = "Asset is already in an auction",
                Success = false
            };
        }
        public async Task<IList<BaseResponse>> AddAssetsForAuctionAsync(HashSet<int> assetIds)
        {
            List<BaseResponse> responses = new List<BaseResponse>();
            foreach(var assetId in assetIds)
            {
                var asset = await _assetRepository.GetAsync(assetId);
                if (asset == null)
                {
                    responses.Add(new BaseResponse
                    {
                        Message = "Asset not found",
                        Success = false
                    });
                }
                if (asset.AssetStatus == AssetStatus.NotAuctioned && asset.IsDeleted == false)
                {
                    asset.AssetStatus = AssetStatus.Auctioned;
                    await _assetRepository.UpdateAsync(asset);
                    responses.Add(new BaseResponse
                    {
                        Message = $"{asset.AssetName} is now in an auction",
                        Success = true
                    });
                }
                responses.Add(new BaseResponse
                {
                    Message = "Asset is already in an auction",
                    Success = false
                });
                
            }
            return responses;
        }
    }
}







