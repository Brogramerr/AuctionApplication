using AuctionApplication.DTOs;

namespace AuctionApplication.DTOs.ResponseModels
{
    public class CustomerResponse : BaseResponse
    {
        public CustomerDto  Data {get;set;}
    }
}