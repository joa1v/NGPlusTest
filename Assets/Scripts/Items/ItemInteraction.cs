using NGPlus.Interactables;
using NGPlus.Inventory;
using UnityEngine;

namespace NGPlus.Item
{
    public class ItemInteraction : Interactable
    {
        [SerializeField] private InventoryItem _inventoryItem;
        public override void Interact()
        {
            base.Interact();
            InventoryManager.Instance.AddItem(_inventoryItem);
            gameObject.SetActive(false);
        }
    }
}