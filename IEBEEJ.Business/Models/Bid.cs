using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Models
{
    public class Bid
    {
        public Bid() { }
        public Bid(int bidderId, decimal bidValue, int itemID)
        {
            BidderId = bidderId;
            BidValue = bidValue;
            ItemId = itemID;
        }
        public int Id { get; set; }

       public decimal BidValue { get; set; }

        public DateTime TimeCreated { get; set; }

        public int ItemId { get; set; }

        public int BidderId { get; set; }

        public bool IsActive { get; set; }

        public Item Item { get; set; }

        public User Bidder { get; set; }

    }
}
