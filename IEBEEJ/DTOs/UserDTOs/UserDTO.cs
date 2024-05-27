using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.OrderDTOs;

namespace IEBEEJ.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public List<SmallBidDTO> Bids { get; set; }

        public List<SmallItemDTO> ItemsForSale { get; set; } //TODO : SmallItemDTO maken.
        public List<SmallOrderDTO> BoughtItems { get; set; } //TODO : SmallOrderDTO maken.
        public List<SmallUserDTO> LikedUsers { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }


    }
}
