namespace IEBEEJ.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        public int WinningBidId { get; set; }
        public decimal TotalPrice { get; set; }
        public string PaymentMethod { get; set; }

        public string ReceivingAdress { get; set; } 

        public string BillingAdress { get; set; }

        public string SendingAdress { get; set; }

        public int StatusId { get; set; }
    }
}
