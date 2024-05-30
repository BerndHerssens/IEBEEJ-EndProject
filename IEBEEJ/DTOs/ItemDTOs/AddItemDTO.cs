using IEBEEJ.DTOs.BidDTOs;
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.DTOs.ItemDTOs
{

    public class AddItemDTO
    {
        [Required]
        public decimal EstimatedValueMax { get; set; }
        [Required]
        public decimal EstimatedValueMin { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        public int Category { get; set; }
        //public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string SendingAdress { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
    }
}