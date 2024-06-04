using System.ComponentModel.DataAnnotations;

namespace IEBEEJ.Data.Entities
{
    public class CategoryEntity 
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public List<ItemEntity> Items { get; set; }
    }
}