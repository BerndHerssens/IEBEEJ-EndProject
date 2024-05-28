using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }

        
        public ItemEntity WonItem { get; set; }

        [Required]
        public int WonItemId { get; set; }

        
        public BidEntity WonBidding { get; set; }
        [Required]
        public int WonBiddingId { get; set; }

        public double TotalCost { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        [Required]
        public int StatusId { get; set; } 
    }
}