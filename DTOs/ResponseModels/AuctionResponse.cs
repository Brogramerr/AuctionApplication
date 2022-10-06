using Dtos.AuctionDto;

namespace AuctionApp.DTOs.ResponseModels
{
    public class AuctionResponse : BaseResponse
    {
        public AuctionDto  Data {get;set;}
    }
}