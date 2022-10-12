namespace AuctionApplication.DTOs.RequestModels
{
    public class CreateAssetRequestModel
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public bool IsOpened { get; set; }
        public int AutioneerId {get;set;}


    }

}