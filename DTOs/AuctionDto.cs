using System;
using AuctionApplication.Entities;

namespace AuctionApplication.DTOs
{
    public class AuctionDto
    {
        public int Id {get; set;}
        public DateTime OpeningDate { get; set; }
        public List<AssetDto> Assets { get; set; } = new List<AssetDto>();
        public int Duration { get; set; }
    }
}