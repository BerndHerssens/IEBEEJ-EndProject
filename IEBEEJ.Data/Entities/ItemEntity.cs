using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Entities
{
    public class ItemEntity
    { 
        public ItemEntity(UserEntity seller) 
        {
        Seller = seller;
        TimeCreated = DateTime.Now;
        }
        
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }

        [Required]
        public UserEntity Seller { get; }

        [Required]
        [StringLength(200)]
        public string ItemDescription { get; set; }

        public List<BidEntity> AllBids { get; set; }

        [Required]
        public int Views { get; set; } = 0;

        [Required]
        public double EstimatedValueMin { get; set; }

        [Required]
        public double EstimatedValueMax { get; set; }

        [Required]
        public double StartingPrice { get; set; }

        [Required]
        public CategoryEntity Category { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public AdressEntity SendingAdress { get; set; }

        public Enum Status { get; set; }

        [Required]
        public DateTime TimeCreated { get ; set ; }

        public DateTime LastModified { get; set; }
    }
}
