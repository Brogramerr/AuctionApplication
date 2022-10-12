using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class CustomerResponseModel : BaseResponse
    {
        public CustomerDto  Data {get;set;}
    }
}