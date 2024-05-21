using IEBEEJ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data.Repositories
{
    public interface IItemRepository
    {
        public List<ItemEntity> GetAllItems(List<ItemEntity> itemList);

        public void AddItem();

        public void RemoveItem(ItemEntity itemEntity);

        public void UpdateItem(ItemEntity itemEntity);

        public ItemEntity GetItemByName(string name);

        public ItemEntity GetItemById(int id);

        public List<ItemEntity> GetItemByUser (int userId);
        
    }
}
