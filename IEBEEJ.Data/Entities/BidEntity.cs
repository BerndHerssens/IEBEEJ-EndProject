
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class BidEntity
    {
        public BidEntity() { }
        public BidEntity(UserEntity bidder, decimal bidValue, int itemID)
        {
            Bidder = bidder;
            BidValue = bidValue;
            ItemID = itemID;
        }
        public int ID { get; set; }
        public decimal BidValue { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public int ItemID {  get; set; }

        public int BidderId { get; set; }
        public UserEntity Bidder { get; set; }
    }
}