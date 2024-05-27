using IEBEEJ.Data.Entities;
using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class ItemDTO
    {
        public decimal EstimatedValueMax { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public decimal StartingPrice { get; set; }
        public int Category { get; set; }
        public int Id { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public DateTime LastModified { get; set; }
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public string SendingAdress { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
        public int AllBidsCount { get; set; }
        public SmallBidDTO[] AllBids { get; set; }
        //public SmallSellerDTO Seller { get; set; }
    }
}
