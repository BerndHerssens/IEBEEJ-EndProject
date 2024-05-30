namespace IEBEEJ.Data.Entities
{
    public class CategoryEntity 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ItemEntity> Items { get; set; }
    }
}