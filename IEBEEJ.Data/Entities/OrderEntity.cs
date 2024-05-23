using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public List<string> PaymentMethod { get; set; }

        [Required]
        public ItemEntity WonItem { get; set; }

        [Required]
        public int WonItemId { get; set; }

        [Required]
        public BidEntity WonBidding { get; set; }
        [Required]
        public int WonBidId { get; set; }

        public double TotalCost { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}