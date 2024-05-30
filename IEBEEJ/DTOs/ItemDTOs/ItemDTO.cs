﻿using IEBEEJ.Data.Entities;
using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.UserDTOs;

namespace IEBEEJ.DTOs.ItemDTOs
{
    public class ItemDTO
    {
        public decimal EstimatedValueMax { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public decimal StartingPrice { get; set; }
        public SmallBidDTO SmallBid { get; set; }
        public int Category { get; set; }
        public int Id { get; set; }
        public SmallUserDTO SmallUser { get; set; }
        public DateTime LastModified { get; set; }
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public string SendingAdress { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }

    }
}
