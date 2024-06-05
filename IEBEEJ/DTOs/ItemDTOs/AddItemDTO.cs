using IEBEEJ.DTOs.BidDTOs;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.DTOs.ItemDTOs
{

    public class AddItemDTO
    {
        
        [Required]
        public decimal StartingPrice { get; set; }
        
        public int CategoryId { get; set; }
        //public int Id { get; set; }
        [Required]
        public int SellerId { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string SendingAdress { get; set; }
    }
}