using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace NGPlus.Inventory
{
    public class InventoryItemUI : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _itemCounter;

        [Header("Description")]
        [SerializeField] private GameObject _descriptionObj;
        [SerializeField] private TextMeshProUGUI _descriptionTMP;

        private IInventoryItem _item;
        private InventorySlotUI _currentSlot;
        private int _itemCount;
        private ObjectPool<InventoryItemUI> _pool;

        private bool _isDragging;

        public IInventoryItem Item => _item;

        public int ItemCount
        {
            get => _itemCount;
            set
            {
                _itemCount = value;
                _itemCounter.text = ItemCount.ToString();
            }
        }

        public void SetItem(IInventoryItem inventoryItem, InventorySlotUI slot, ObjectPool<InventoryItemUI> pool)
        {
            _item = inventoryItem;
            _currentSlot = slot;
            _pool = pool;

            _itemIcon.color = Color.white;
            _itemIcon.sprite = inventoryItem.Icon;

            ItemCount++;

            _descriptionTMP.text = inventoryItem.Description;
            SetDescription(false);
        }

        public void SetSlot(InventorySlotUI slot)
        {
            _currentSlot = slot;
        }

        #region Interaction interfaces
        public void OnPointerClick(PointerEventData eventData)
        {
            if (_item is ConsumableItem consumable && !_isDragging)
            {
                consumable.Consume();
                InventoryManager.Instance.RemoveItem(_item);
                ItemCount--;
                if (ItemCount <= 0)
                {
                    ResetItemUI();
                }
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            SetDescription(false);

            _isDragging = true;

            _currentSlot.SetEmpty();
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            bool isInsideInventory = InventoryUI.Instance.CheckMouseIsInsideInventory();
            if (isInsideInventory)
            {
                TrySnapToClosestSlot(eventData.position);
            }
            else
            {
                ReturnToOldSlot();
            }

            _isDragging = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            SetDescription(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            SetDescription(false);
        }
        #endregion

        private void TrySnapToClosestSlot(Vector2 position)
        {
            var slot = InventoryUI.Instance.GetClosestSlot(position);
            if (slot.CheckCanAddItem(this))
            {
                _currentSlot.SetEmpty();
                slot.AddItem(this);
            }
            else
            {
                ReturnToOldSlot();
            }
        }

        private void ReturnToOldSlot()
        {
            _currentSlot.AddItem(this);
        }

        public void ResetItemUI()
        {
            ItemCount = 0;
            _item = null;
            _currentSlot.SetEmpty();
            _currentSlot = null;

            _pool?.Release(this);
        }

        private void SetDescription(bool set)
        {
            _descriptionObj.gameObject.SetActive(set);
        }


    }
}
