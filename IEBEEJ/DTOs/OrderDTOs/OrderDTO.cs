using IEBEEJ.Business;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int BuyerId { get; set; }

        public ItemForOrderDTO Item { get; set; }

        public UserForOrderDTO Buyer { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PriceTotal { get; set;}

        public DateTime Created { get; set; }

        public StatusType Status { get; set; }

        public int StatusId { get; set; }


    }
}
