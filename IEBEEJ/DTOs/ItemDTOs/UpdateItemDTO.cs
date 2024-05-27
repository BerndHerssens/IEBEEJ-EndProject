﻿namespace IEBEEJ.DTOs.ItemDTOs
{
    public class UpdateItemDTO
    {
        public decimal EstimatedValueMax { get; set; }
        public decimal EstimatedValueMin { get; set; }
        public decimal StartingPrice { get; set; }
        public int Category { get; set; }
        public int Id {  get; set; }
        public int SellerID { get; set; }
        public string ItemDescription { get; set; }
        public string ItemName { get; set; }
        public string SendingAdress { get; set; }
    }
}