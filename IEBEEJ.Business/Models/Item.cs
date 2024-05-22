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
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal StartingPrice { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime TimeEnds { get; set; }

        public int SellerID { get; set; }

        public List<Bid> Bids { get; set; }

        public bool IsActive { get; set; }

        public bool IsSold { get; set; }

        public CategoryType Category { get; set; }
    }
}
