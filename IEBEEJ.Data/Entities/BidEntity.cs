
using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class BidEntity : IEntity
    {

        public int Id { get; set; }
        public decimal BidValue { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int ItemID { get; set; }
        public ItemEntity Item {  get; set; }
        public int BidderId { get; set; }
        public UserEntity User { get; set; }
        public bool IsActive { get; set; }
    }
}