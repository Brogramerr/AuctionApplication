<<<<<<< HEAD
using System;
using AuctionApp.Enum;
=======
using AuctionApplication.Enum;
>>>>>>> 825df9a3e599be0a1ebff0b3e3c1f651342e4395

namespace Dtos.AuctionDto
{
    public class AuctionDto
    {
        public decimal StartingPrice { get; set; }
        public string AssetName { get; set; }
        public DateTime ExpiryDate { get;set; }
        public AuctionType AuctionType { get; set; }

    }
}