using IEBEEJ.Data.Entities;

namespace IEBEEJ.DTO
{
    public class ItemDTO
    {
        public int Category { get; set; }
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public decimal EstimatedValueMax { get; set; }
        public string SendingAdress { get; set; }
        public int SellerID { get; set; }

    }
}
