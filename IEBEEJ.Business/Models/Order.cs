using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Models
{
    public class Order
    {
        public User Buyer { get; set; }
        public int BuyerID { get; set; }
        public int Id { get; set; }

        public bool IsActive { get; set; }
        public Item Item { get; set; }
        public int ItemID { get; set; }
        public int WonBiddingID { get; set; }
        public Bid WonBidding { get; set; }
        public int WonItemID { get; set; }
        public string PaymentMethod { get; set; }
        public StatusType Status { get; set; }
        public int StatusId { get; internal set; }
        public DateTime TimeCreated { get; set; }

        public decimal TotalCost { get; set; }
    }
}
