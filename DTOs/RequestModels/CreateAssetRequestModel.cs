using AuctionApplication.Entities.Enums;

namespace AuctionApplication.DTOs.RequestModels
{
    public class CreateAssetRequestModel
    {
        public decimal Price { get; set; }

       public string ImageUrl { get; set; }
        public string AssetName { get; set; }
        public bool AuctionPriceIsOpened { get; set; }

        public AssetStatus AssetStatus{get; set;}
    }

}