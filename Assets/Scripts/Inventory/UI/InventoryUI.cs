using NGPlus.Singleton;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

namespace NGPlus.Inventory
{
    public class InventoryUI : Singleton<InventoryUI>
    {
        [SerializeField] private InventorySlotUI[] _inventorySlots;
        [SerializeField] private InventoryItemUI _inventoryItemUIPrefab;

        private ObjectPool<InventoryItemUI> _inventoryItemPool;

        protected override void Awake()
        {
            base.Awake();

            _inventoryItemPool = new ObjectPool<InventoryItemUI>(
                                        createFunc: () => Instantiate(_inventoryItemUIPrefab, transform),
                                        actionOnGet: (item) => item.gameObject.SetActive(true),
                                        actionOnRelease: (item) => item.gameObject.SetActive(false));
        }

        public void AddInventoryUI(IInventoryItem inventoryItem)
        {
            var itemUI = _inventoryItemPool.Get();


            var slot = _inventorySlots.Where(x => x.IsAvailable).FirstOrDefault();
            if (slot != null)
            {
                slot.AddItem(itemUI);
                itemUI.SetItem(inventoryItem, slot, _inventoryItemPool);
            }
        }

        public InventorySlotUI GetClosestSlot(Vector2 position)
        {
            float closestDistance = Mathf.Infinity;
            InventorySlotUI closestSlot = _inventorySlots[0];

            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                var gridSlot = _inventorySlots[i];
                var distance = Vector2.Distance(position, gridSlot.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestSlot = gridSlot;
                }
            }

            return closestSlot;
        }

        public bool CheckMouseIsInsideInventory()
        {
            return RectTransformUtility.RectangleContainsScreenPoint((RectTransform)transform, Input.mousePosition);
        }

        private void OnValidate()
        {
            _inventorySlots = GetComponentsInChildren<InventorySlotUI>();
        }
    }
}
