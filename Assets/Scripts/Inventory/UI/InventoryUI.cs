using NGPlus.Singleton;
using UnityEngine;

namespace NGPlus.Inventory
{
    public class InventoryUI : Singleton<InventoryUI>
    {
        [SerializeField] private InventorySlotUI[] _inventorySlots;


        public void UpdateInventoryUI()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (i < InventoryManager.Instance.Items.Count)
                {
                    var item = InventoryManager.Instance.Items[i];
                    _inventorySlots[i].SetItem(item);
                }
                else
                {
                    _inventorySlots[i].SetEmpty();
                }
            }

        }

        private void OnValidate()
        {
            _inventorySlots = GetComponentsInChildren<InventorySlotUI>();
        }
    }
}
