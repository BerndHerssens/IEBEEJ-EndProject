
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class BidEntity : IEntity
    {
        public BidEntity() { }
        public BidEntity(UserEntity bidder, decimal bidValue, int itemID)
        {
            Bidder = bidder;
            BidValue = bidValue;
            ItemID = itemID;
        }
        public int Id { get; set; }
        public decimal BidValue { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int ItemID { get; set; }

        public ItemEntity Item { get; set; }
        public int BidderId { get; set; }
        public UserEntity Bidder { get; set; }
        public bool IsActive { get; set; }
    }
}