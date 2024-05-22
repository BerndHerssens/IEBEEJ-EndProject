
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class BidEntity
    {
        public BidEntity(UserEntity bidder, decimal bidValue) {
            Bidder = bidder;
            BidValue = bidValue;
        }
        public int ID { get; set; }
        public decimal BidValue { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;

        public int BidderId { get; set; }
        public UserEntity Bidder { get; set; }
    }
}