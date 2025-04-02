using UnityEngine;

namespace NGPlus.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/HealthPotion")]
    public class HealthPotionItem : ConsumableItem
    {
        [SerializeField] private float _healAmount;
        public override void Consume()
        {
            Debug.Log($"increasing life in {_healAmount} points");
        }
    }
}
