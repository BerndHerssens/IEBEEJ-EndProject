using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class CategoryEntity 
    {
        [Required]
        public int Id { get; set; }
        
        public string Name { get; set; }
    }
}