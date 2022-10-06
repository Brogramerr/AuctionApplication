using AuctionApplication.DTOs;

namespace AuctionApp.DTOs.ResponseModels
{
    public class CustomerResponse : BaseResponse
    {
        public CustomerDto  Data {get;set;}
    }
}