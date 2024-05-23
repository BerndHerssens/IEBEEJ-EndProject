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
        public Item(User seller)
        {
            Seller = seller;
            Created = DateTime.Now;
        }

        public List<Bid> AllBids { get; set; }

        public Bid? HighestBid { get; set; }

        public CategoryType Category { get; set; }

        public int CategoryID { get; set; }

        public DateTime Created { get; set; }

        public string ItemDescription { get; set; }

        public DateTime EndDate { get; set; }

        public int Id { get; set; }

        public bool IsActive { get; set; }

        public bool IsSold { get; set; }

        public string ItemName { get; set; }

        public User Seller { get; set; }

        public int SellerID { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal EstimatedValueMin { get; set; }

        public decimal EstimatedValueMax { get; set; }

        public string SendingAdress { get; set; }
    }
}
