using IEBEEJ.Business.Models;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.BidDTOs
{
    public class AddBidDTO
    {
        public decimal BidValue { get; set; }
        public int ItemID { get; set; }
        public ItemForBidDTO Item { get; set; }
        public int BidderId { get; set; }
        public SmallUserDTO Bidder { get; set; }
        public bool IsActive { get; set; }

    }
}
