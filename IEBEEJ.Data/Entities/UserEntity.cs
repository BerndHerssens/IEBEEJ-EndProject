using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IEBEEJ.Data.Entities
{
    public class UserEntity
    {

        public UserEntity(Enum role) 
        {
            Role = role;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public List<AdressEntity> Adresses { get; set; }

        public List<BidEntity> Bids { get; set; }

        public List<ItemEntity> ItemsForSale { get; set; } //TODO: tezamen?

        public List<OrderEntity> BoughtItems {  get; set; }

        public List<UserEntity> LikedUsers { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        private Enum Role { get; set; }
    }
}