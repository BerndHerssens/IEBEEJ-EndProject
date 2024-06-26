﻿using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class OrderEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string SellerName { get; set; }
        public string SendAdress { get; set; }
        public int BuyerId { get; set; }
        public UserEntity Buyer { get; set; }
        public bool IsActive { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }
        [Required]
        public int StatusId { get; set; }
        public decimal TotalCost { get; set; }
        [Required]
        public int ItemId { get; set; }
    }
}