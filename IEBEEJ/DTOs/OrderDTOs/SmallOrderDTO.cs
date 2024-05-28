using IEBEEJ.Business.Models;
using IEBEEJ.Business;

namespace IEBEEJ.DTOs.OrderDTOs
{
    public class SmallOrderDTO
    {
        public int Id { get; set; }

        public int ItemID { get; set; }

        public int BuyerID { get; set; }
    }
}
