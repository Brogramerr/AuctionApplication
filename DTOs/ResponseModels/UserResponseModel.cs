using Dtos.AuctionDto;

namespace AuctionApp.DTOs.ResponseModels
{
    public class UserResponseModel : BaseResponse 
    {
        public UserDto Data { get;set; }
    }
}