using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        public int WinningBidId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }

        public ItemForOrderDTO Item { get; set; }

        public UserForOrderDTO Buyer { get; set; }

        public int StatusId { get; set; }
    }
}
