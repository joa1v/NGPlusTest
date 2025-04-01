using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NGPlus.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _itemIcon;

        private IInventoryItem _currentItem;

        public void SetItem(IInventoryItem item)
        {
            _currentItem = item;
            _itemIcon.color = Color.white;
            _itemIcon.sprite = item.Icon;
        }

        public void SetEmpty()
        {
            _currentItem = null;
            _itemIcon.color = Color.clear;
            _itemIcon.sprite = null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_currentItem is ConsumableItem consumable)
            {
                consumable.Consume();
                InventoryManager.Instance.RemoveItem(_currentItem);
            }
        }
    }
}
