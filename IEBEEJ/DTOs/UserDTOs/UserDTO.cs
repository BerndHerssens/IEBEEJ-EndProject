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
        //public SmallBidDTO[] Bids { get; set; }

        //public SmallItemDTO[] ItemsForSale { get; set; } 
        //public SmallOrderDTO[] BoughtItems { get; set; } 
        //public SmallUserDTO[] LikedUsers { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
    }
}
