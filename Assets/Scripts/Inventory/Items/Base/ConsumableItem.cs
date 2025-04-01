using UnityEngine;

namespace NGPlus.Inventory
{
    public abstract class ConsumableItem : InventoryItem
    {
        public abstract void Consume();
    }
}
