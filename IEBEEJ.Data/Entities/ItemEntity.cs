using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        public int CategoryId { get; set; }
        //public CategoryEntity Category { get; set; }

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
        [StringLength(200)]
        public string ItemDescription { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        public DateTime LastModified { get; set; }

        public UserEntity Seller { get; } //UserEntity is een aparte tabel

        [Required]
        public int SellerID { get; set; }

        public string SendingAdress { get; set; }

        [Required]
        public decimal StartingPrice { get; set; }

        //[Required]
        /*public int Views { get; set; } = 0;*/ //Nice To Have

        //Nice To Have

        //Nice To Have //decimal voor value's bij currency
    }
}
