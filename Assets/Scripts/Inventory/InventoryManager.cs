using NGPlus.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace NGPlus.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        [SerializeField] private int _maxItems = 6;
        private Dictionary<IInventoryItem, int> _items = new Dictionary<IInventoryItem, int>();
        public IReadOnlyDictionary<IInventoryItem, int> Items => _items;

        public void AddItem(IInventoryItem item)
        {
            if (_items.TryGetValue(item, out int quantity))
            {
                _items[item] = quantity + 1;
            }
            else if (_items.Count < _maxItems)
            {
                _items.Add(item, 1);
            }
            else
            {
                Debug.Log("Inventory is full");
            }

            Debug.Log($"Adding: {item.ItemName}");
            InventoryUI.Instance.AddInventoryUI(item);
        }

        public void RemoveItem(IInventoryItem item)
        {
            if (_items.TryGetValue(item, out int quantity))
            {
                if (quantity > 1)
                {
                    _items[item] = quantity - 1;
                }
                else
                {
                    _items.Remove(item);
                }

                Debug.Log($"Removing: {item.ItemName}");
            }
        }

        public void ClearInventory()
        {
            _items.Clear();
        }
    }
}
