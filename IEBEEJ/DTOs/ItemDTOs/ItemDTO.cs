using IEBEEJ.Data.Entities;
using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal EstimatedValueMax { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SmallBidDTO> AllBids { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SendingAdress { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
    }
}
