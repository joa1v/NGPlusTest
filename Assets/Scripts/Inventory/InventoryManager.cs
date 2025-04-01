using NGPlus.Singleton;
using System.Collections.Generic;
using UnityEngine;

namespace NGPlus.Inventory
{
    public class InventoryManager : Singleton<InventoryManager>
    {
        private List<IInventoryItem> _items = new List<IInventoryItem>();
        public IReadOnlyList<IInventoryItem> Items => _items;

        public void AddItem(IInventoryItem item)
        {
            _items.Add(item);
            Debug.Log($"Adicionado: {item.ItemName}");
            InventoryUI.Instance.UpdateInventoryUI();
        }

        public void RemoveItem(IInventoryItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                Debug.Log($"Removido: {item.ItemName}");
                InventoryUI.Instance.UpdateInventoryUI();
            }
        }
    }
}
