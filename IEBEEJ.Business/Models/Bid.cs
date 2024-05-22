using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Models
{
    public class Bid
    {
        public int ID { get; set; }

       public decimal BidValue { get; set; }

        public DateTime TimeCreated { get; set; }

        public int ItemID { get; set; }

        public int BidderID { get; set; }

        public virtual Item Item { get; set; }

        public virtual User User { get; set; }
    }
}
