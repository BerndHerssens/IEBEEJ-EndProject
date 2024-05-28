namespace IEBEEJ.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        public int ItemId { get; set; }
        public int BuyerId { get; set; }
        public decimal Price { get; set; }
        public string PaymentMethod { get; set; }

        public string ReceivingAdress { get; set; } 

        public string BillingAdress { get; set; }
    }
}
