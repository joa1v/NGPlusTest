using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NGPlus.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _itemCounter;
        private IInventoryItem _currentItem;

        public void SetItem(IInventoryItem item, int count)
        {
            _currentItem = item;
            _itemIcon.color = Color.white;
            _itemIcon.sprite = item.Icon;
            _itemCounter.text = count.ToString();
        }

        public void SetEmpty()
        {
            _currentItem = null;
            _itemIcon.color = Color.clear;
            _itemIcon.sprite = null;
            _itemCounter.text = string.Empty;
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
