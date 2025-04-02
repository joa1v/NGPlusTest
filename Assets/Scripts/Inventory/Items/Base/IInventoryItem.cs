using UnityEngine;

namespace NGPlus.Inventory
{
    public interface IInventoryItem
    {
        string ItemName { get; }
        string Description { get; }
        Sprite Icon { get; }
        ItemType Type { get; }
    }

    public enum ItemType
    {
        HealthPotion,
        Crystal
    }
}
