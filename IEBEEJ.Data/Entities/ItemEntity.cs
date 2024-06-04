using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Entities
{
    public class ItemEntity : IEntity
    {
        public int Id { get; set; }

        public List<BidEntity> AllBids { get; set; }

        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; } //TODO: nog kijken om de categoryFK te linken aan een item.

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public decimal EstimatedValueMax { get; set; }

        [Required]
        public decimal EstimatedValueMin { get; set; }

        public bool IsActive { get; set; }

        public bool IsSold { get; set; }

        [Required]
        [MaxLength(200)]
        public string ItemDescription { get; set; }

        [Required]
        [MaxLength(50)]
        public string ItemName { get; set; }

        public DateTime LastModified { get; set; }

        [ForeignKey("User")]
        public int SellerId { get; set; }

        public UserEntity Seller { get; set; } //UserEntity is een aparte tabel
        [MaxLength(200)]
        public string SendingAdress { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }

        //[Required]
        //public int Views { get; set; } = 0;*/ //Nice To Have
    }
}