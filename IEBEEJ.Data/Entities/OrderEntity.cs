using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class OrderEntity
    {
        public int ID { get; set; }
        public List<string> PaymentMethod { get; set; }

        [Required]
        public ItemEntity WonItem { get; set; }

        [Required]
        public BidEntity WonBidding { get; set; }

        public double TotalCost { get; set; }
    }
}