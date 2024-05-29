using IEBEEJ.Business.Models;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class ItemForBidDTO
    {
        public Bid? HighestBid { get; set; } 
        public bool IsActive { get; set; } = true;
        public int SellerId { get; set; }

    }
}
