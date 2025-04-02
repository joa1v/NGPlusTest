using NGPlus.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace NGPlus.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        private Dictionary<IInventoryItem, int> _items = new Dictionary<IInventoryItem, int>();
        public IReadOnlyDictionary<IInventoryItem, int> Items => _items;

        public void AddItem(IInventoryItem item)
        {
            if (_items.TryGetValue(item, out int quantity))
            {
                _items[item] = quantity + 1;
            }
            else
            {
                _items.Add(item, 1);
            }

            Debug.Log($"Adicionado: {item.ItemName}");
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

                Debug.Log($"Removido: {item.ItemName}");
                //InventoryUI.Instance.UpdateInventoryUI();
            }
        }
    }
}
