using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace IEBEEJ.Data.Entities
{
    public class UserEntity : IEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(int role) 
        {
            Role = role;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        public string Password { get; set; }

        [Required]
        public string Adress { get; set; }

        public List<BidEntity> Bids { get; set; }

        public List<ItemEntity> ItemsForSale { get; set; } //TODO: tezamen?

        //public List<OrderEntity> BoughtItems {  get; set; }

        public List<UserEntity> LikedUsers { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Birthday { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        //[Required]
        public int Role { get; set; }
    }
}