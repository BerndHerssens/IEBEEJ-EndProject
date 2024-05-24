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
        public int ID { get; set; }

        public int ItemID { get; set; }

        public Item Item { get; set; }

        public int BuyerID { get; set; }

        public decimal Price { get; set; }

        public DateTime TimeCreated { get; set; }

        public bool IsActive { get; set; }

        public StatusType Status { get; set; }
    }
}
