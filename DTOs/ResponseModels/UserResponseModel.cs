using Dtos.AuctionDto;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class UserResponseModel : BaseResponse 
    {
        public UserDto Data { get;set; }
    }
}