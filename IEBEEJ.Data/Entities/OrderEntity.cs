using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class OrderEntity : IEntity
    {
        public DateTime Created { get; set; } = DateTime.Now;
        public int Id { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        public int StatusId { get; set; }

        public StatusEntity Status { get; set; }

        public decimal TotalCost { get; set; }

        public BidEntity WonBidding { get; set; }

        [Required]
        public int WonBiddingId { get; set; }

        public ItemEntity WonItem { get; set; }

        [Required]
        public int WonItemId { get; set; }
    }
}