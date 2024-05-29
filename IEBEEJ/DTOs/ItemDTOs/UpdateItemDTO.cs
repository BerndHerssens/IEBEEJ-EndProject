using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class UpdateItemDTO
    {
        [Required]
        public decimal EstimatedValueMax { get; set; }
        [Required]
        public decimal EstimatedValueMin { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        public int Category { get; set; }
        [Required]
        [MinLength(1)]
        public int Id {  get; set; }
        [Required]
        public int SellerID { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string SendingAdress { get; set; }
    }
}