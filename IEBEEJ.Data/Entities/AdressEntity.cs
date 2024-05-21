using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class AdressEntity
    {
        [Required]
        public string Country { get; set; }

        [StringLength(50)]
        public string Province { get; set; }

        [Required]
        [StringLength(86)]
        public string City { get; set; }

        [Required]
        [StringLength(300)]
        public string Street { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        public string Bus {  get; set; }
    }
}