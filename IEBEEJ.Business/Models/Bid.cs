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
            BidderID = bidderId;
            BidValue = bidValue;
            ItemID = itemID;
        }
        public int Id { get; set; }

       public decimal BidValue { get; set; }

        public DateTime TimeCreated { get; set; }

        public int ItemID { get; set; }

        public int BidderID { get; set; }

        public bool IsActive { get; set; }

        public Item Item { get; set; }

        public User Bidder { get; set; }

    }
}
