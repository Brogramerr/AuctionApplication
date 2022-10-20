using AuctionApplication.DTOs;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Entities;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Implementation.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }

        public async Task<BaseResponse> ChangeAuctionDurationAsync(int id, int days)
        {
            var auction = await _auctionRepository.GetAsync(x => x.Id == id);
            if (auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not found",
                    Success = false,
                };
            }
            if (auction.OpeningDate <= DateTime.Now)
            {
                return new BaseResponse()
                {
                    Message = "Auction has Started",
                    Success = false,
                };
            }

            auction.Duration = days;
            await _auctionRepository.UpdateAsync(auction);
            return new BaseResponse()
            {
                Message = "Auction duration extended",
                Success = true,
            };
        }

        public async Task<BaseResponse> ChangeAuctionOpeningDateAsync(int id, DateTime openingDate)
        {
            var auction = await _auctionRepository.GetAsync(id);
            if (auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not found",
                    Success = false,
                };
            }
            if (auction.OpeningDate <= DateTime.Now)
            {
                return new BaseResponse()
                {
                    Message = "Auction has Started",
                    Success = false,
                };
            }

            auction.OpeningDate = openingDate;
            await _auctionRepository.UpdateAsync(auction);
            return new BaseResponse()
            {
                Message = "Auction opening date changed",
                Success = true,
            };
        }

        public async Task<BaseResponse> CreateAuctionAsync(CreateAuctionRequestModels model)
        {
            var auction = new Auction
            {
                OpeningDate = model.OpeningDate,
                Duration = model.Duration,
            };
            await _auctionRepository.CreateAsync(auction);
            return new BaseResponse()
            {
                Message = "Auction Creation Success",
                Success = false,
            };
        }
        public async Task<AuctionsResponseModel> GetAllAuctions()
        {
            var auction = await _auctionRepository.GetAllAuction();

            var auctionList = auction.Select(auct => new AuctionDto (){
                Id = auct.Id,
                OpeningDate = auct.OpeningDate,
                Duration = auct.Duration
            }).ToList();
            return new AuctionsResponseModel()
            {
                Data = auctionList,
                Message = "Auction Creation Success",
                Success = false,
            };
        }

    }
}