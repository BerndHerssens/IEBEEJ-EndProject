using IEBEEJ.Business;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class UpdateOrderDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }

        public int BuyerId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PriceTotal { get; set;}
        public string ItemName { get; set; }
        public string SendingAdress { get; set; }
        public string ReceivingAdress { get; set; }
        public string BillingAdress { get; set; }

        public string BuyerName { get; set; }

        public DateTime Created { get; set; }

        public StatusType Status { get; set; }

        public int StatusId { get; set; }
    }
}
