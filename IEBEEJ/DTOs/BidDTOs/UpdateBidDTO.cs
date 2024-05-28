using IEBEEJ.Business.Models;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.BidDTOs
{
    public class UpdateBidDTO
    {
        public decimal BidValue { get; set; }

        public int ItemID { get; set; }
        public bool IsActive { get; set; }

        public int BidderID { get; set; }
        public ItemForBidDTO Item { get; set; }

        public SmallUserDTO Bidder { get; set; }

    }
}
