using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.UserDTOs;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class AddOrderDTO
    {
        [Required]
        public int ItemId { get; set; }
        public int BuyerId { get; set; }
    }
}
