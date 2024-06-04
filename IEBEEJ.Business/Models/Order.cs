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
        public int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public string SellerName { get; set; }
        public string SendAdress { get; set; }
        public int BuyerID { get; set; }
        public string BuyerName { get; set; }
        public string BuyerAdress { get; set; }
        public bool IsActive { get; set; }
        public string PaymentMethod { get; set; }
        public int StatusId { get; set; }    
        public decimal TotalCost { get; set; }
        public int ItemId { get; set; }
    }
}
