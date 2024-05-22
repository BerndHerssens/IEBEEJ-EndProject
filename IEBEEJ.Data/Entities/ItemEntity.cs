using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Entities
{
    public class ItemEntity : IEntity
    {
        public ItemEntity() { }
        public ItemEntity(UserEntity seller) 
        {
        Seller = seller;
        Created = DateTime.Now;
        }
  
        public int Id { get ; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        public UserEntity Seller { get; } //UserEntity is een aparte tabel

        [Required]
        public int SellerID { get; set; }

        [Required]
        [StringLength(200)]
        public string ItemDescription { get; set; }

        public List<BidEntity> AllBids { get; set; }

        [Required]
        public int Views { get; set; } = 0; //Nice To Have

        [Required]
        public decimal EstimatedValueMin { get; set; } //Nice To Have

        [Required]
        public decimal EstimatedValueMax { get; set; } //Nice To Have //decimal voor value's bij currency

        [Required]
        public decimal StartingPrice { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string SendingAdress { get; set; }

        [Required]
        public int StatusId { get; set; }
        public StatusEntity Status { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsActive { get; set; }

        [Required]
        public DateTime Created { get; set; }
    }
}
