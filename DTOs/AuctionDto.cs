using System;
using AuctionApplication.Entities;

namespace AuctionApplication.DTOs
{
    public class AuctionDto
    {
        public DateTime OpeningDate { get; set; }
        public List<Asset> Assets { get; set; } = new List<Asset>();
        public int Duration { get; set; }
    

    }
}