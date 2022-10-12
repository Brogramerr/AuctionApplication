using AuctionApplication.Entities.Identity;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Interface.Services;
using System;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Entities;
using AuctionApplication.DTOs;

namespace AuctionApplication.Implementation.Services
{
    public class AuctionService : IAuctionService

    {
        private readonly IAuctionRepository _repository;
        public AuctionService(IAuctionRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse> ChangeAuctionDurationAsync(int id, int days)
        {
            var auction = await  _repository.GetAsync(x => x.Id == id);
            if(auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not found",
                    Success = false,
                };
            }
            if(auction.OpeningDate <= DateTime.Now)
            {
                 return new BaseResponse()
                {
                    Message = "Auction has Started",
                    Success = false,
                };
            }
            
             auction.Duration = days;
             var auct =  await _repository.UpdateAsync(auction);

                 if(auct != null)
                {
                    return new BaseResponse()
                    {
                        Message = "Auction Updated Successfully",
                        Success = true,
                    };
                }
                    return new BaseResponse()
                    {
                        Message = "Auction Update Failed",
                        Success = false,
                    };
        }

        public async Task<BaseResponse> ChangeAuctionOpeningDateAsync(int id, DateTime openingDate)
        {
            var auction = await  _repository.GetAsync(id);
            if(auction == null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Not found",
                    Success = false,
                };
            }
            if(auction.OpeningDate <= DateTime.Now)
            {
                 return new BaseResponse()
                {
                    Message = "Auction has Started",
                    Success = false,
                };
            }
            
             auction.OpeningDate = openingDate;
             var auct =  await _repository.UpdateAsync(auction);

            if(auct != null)
                {
                    return new BaseResponse()
                    {
                        Message = "Auction Updated Successfully",
                        Success = true,
                    };
                }
                    return new BaseResponse()
                    {
                        Message = "Auction Update Failed",
                        Success = false,
                    };
        }

        public async Task<BaseResponse> CreateAuctionAsync(CreateAuctionRequestModels model)
        {
            var auction = new Auction()
            {
                OpeningDate = model.OpeningDate,
                Duration = model.Duration,
            };
             var create = await _repository.CreateAsync(auction);
            if(create != null)
            {
                return new BaseResponse()
                {
                    Message = "Auction Created Successfully",
                    Success = true,
                };
            }
                 return new BaseResponse()
                {
                    Message = "Auction Creation Failed",
                    Success = false,
                };
        }


    }
}