using IEBEEJ.Business;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int WonBiddingId { get; set; }
        public SmallItemDTO Item { get; set; }
        public string SellerName { get; set; }
        public string SendAdress { get; set; }
        public int BuyerId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalCost { get; set;}
        public DateTime Created { get; set; }
        public int StatusId { get; set; }
    }
}
