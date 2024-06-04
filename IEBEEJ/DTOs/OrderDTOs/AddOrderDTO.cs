using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        [Required]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string SellerName { get; set; }
        public string SendingAdress { get; set; }
        public int BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAdress { get; set; }
        public decimal TotalPrice { get; set; }
        public int StatusId { get; set; }
    }
}
