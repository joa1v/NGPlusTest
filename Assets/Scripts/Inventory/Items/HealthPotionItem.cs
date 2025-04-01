using UnityEngine;

namespace NGPlus.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/HealthPotion")]
    public class HealthPotionItem : ConsumableItem
    {
        public override void Consume()
        {
            Debug.Log("aumentando vida");
        }
    }
}
