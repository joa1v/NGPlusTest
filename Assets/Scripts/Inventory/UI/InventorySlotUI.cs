using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NGPlus.Inventory
{
    public class InventorySlotUI : MonoBehaviour
    {

        public bool IsAvailable => _currentItem == null;

        private int _itemCount;
        private InventoryItemUI _currentItem;

        public void AddItem(InventoryItemUI item)
        {
            if (_currentItem != null)
            {
                _currentItem.ItemCount += item.ItemCount;
                item.ResetItemUI();
            }
            else
            {
                _currentItem = item;
                _currentItem.SetSlot(this);
                item.transform.position = transform.position;
            }
        }

        public bool CheckCanAddItem(InventoryItemUI itemToAdd)
        {
            return IsAvailable || itemToAdd.Item == _currentItem.Item;
        }

        public void SetEmpty()
        {
            _currentItem = null;
        }
    }
}
