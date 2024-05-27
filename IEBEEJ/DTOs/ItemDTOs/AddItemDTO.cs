using IEBEEJ.DTOs.BidDTOs;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class AddItemDTO
    {
        public decimal EstimatedValueMax { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public decimal StartingPrice { get; set; }
        public int Category { get; set; }
        //public int Id { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public string SendingAdress { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
    }
}