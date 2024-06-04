using IEBEEJ.Business.Models;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.BidDTOs
{
    public class AddBidDTO
    {
        public decimal BidValue { get; set; }
        public int ItemId { get; set; }
        public int BidderId { get; set; }
        // public bool IsActive { get; set; }

    }
}
