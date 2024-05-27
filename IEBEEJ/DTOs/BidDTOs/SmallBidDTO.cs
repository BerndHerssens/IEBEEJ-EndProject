namespace IEBEEJ.DTOs.BidDTOs
{
    public class SmallBidDTO
    {
        public int Id { get; set; }
        public decimal BidValue { get; set; }
        public int BidderID { get; set; }
        public DateTime Created { get; set; }
    }
}
