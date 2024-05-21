﻿
namespace IEBEEJ.Data.Entities
{
    public class BidEntity
    {
        public BidEntity(UserEntity bidder, double bidValue) {
            Bidder = bidder;
            BidValue = bidValue;
        }
        public int ID { get; set; }
        public double BidValue { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public UserEntity Bidder { get; set; }
    }
}