using UnityEngine;

namespace NGPlus.Inventory
{
    public abstract class InventoryItem : ScriptableObject, IInventoryItem
    {
        [SerializeField] private string _itemName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemType _itemType;

        public string ItemName => _itemName;
        public string Description => _description;
        public Sprite Icon => _icon;
        public ItemType Type => _itemType;
    }
}
