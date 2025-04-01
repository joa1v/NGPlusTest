using UnityEngine;

namespace NGPlus.Inventory
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Inventory/QuestItem")]
    public class QuestItem : InventoryItem
    {
        [SerializeField] private string _questDescription;

        public string QuestDescription => _questDescription;
    }
}
