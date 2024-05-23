using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEBEEJ.Data.Entities;

namespace IEBEEJ.Business.Models
{
    public class Item
    {
        public Item() { }
        public Item(int sellerId)
        {
            SellerId = sellerId;
        }

        public List<Bid> AllBids { get; set; }
        //TODO: move from service to here
        public Bid? HighestBid { get; set; }

        public CategoryType Category { get; set; }

        public int CategoryId { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string ItemDescription { get; set; }

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);

        public int Id { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsSold { get; set; } = false;

        public string ItemName { get; set; }

        public User Seller { get; set; }

        public int SellerId { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal EstimatedValueMin { get; set; }

        public decimal EstimatedValueMax { get; set; }

        public string SendingAdress { get; set; }
    }
}
