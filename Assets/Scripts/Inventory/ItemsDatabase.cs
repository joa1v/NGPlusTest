using NGPlus.Singleton;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGPlus.Inventory
{
    public class ItemsDatabase : Singleton<ItemsDatabase>
    {
        [SerializeField] private string _itemsPath;
        [SerializeField] private InventoryItem[] _inventoryItems;

        public InventoryItem GetItemByID(string id)
        {
            return _inventoryItems.Where(x => x.ItemName == id).FirstOrDefault();
        }

        private void OnValidate()
        {
            _inventoryItems = Resources.LoadAll<InventoryItem>(_itemsPath).ToArray();
        }
    }
}
